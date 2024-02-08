using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace Holding.Controllers
{
    public class CompanyProjectController : Controller
    {
        private readonly IRepository<CompanyProject> _cpRepo;
        private readonly IRepository<Company> _companyRepo;
        private readonly IRepository<Project> _projectRepo;

        public CompanyProjectController(IRepository<CompanyProject> cpRepo, IRepository<Company> companyRepo, IRepository<Project> projectRepo)
        {
            _cpRepo = cpRepo;
            _companyRepo = companyRepo;
            _projectRepo = projectRepo;
        }
        // GET: CompanyProject
        public async Task<ActionResult> Index()
        {
            var cp = await _cpRepo.List.Include(c => c.Company).Include(p => p.Project).ToListAsync();
            return View(cp);
        }

        // GET: CompanyProject/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyProject/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Companies = new SelectList(await _companyRepo.List.ToListAsync(), "CompanyID", "CompanyName");
            ViewBag.Projects = new SelectList(await _projectRepo.List.ToListAsync(), "ProjectID", "ProjectName");
            return View();
        }

        // POST: CompanyProject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyProject cp)
        {
            try
            {
                _cpRepo.Create(cp);
                TempData["status"] = "Yeni Şirket-Proje ilişkisi başarılı şekilde eklendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cp);
            }
        }

        // GET: CompanyProject/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null) NotFound();
            var cd = await _cpRepo.List.FirstOrDefaultAsync(x => x.CompanyProjectID == id);
            ViewBag.CompanySelect = new SelectList(await _companyRepo.List.ToListAsync(), "CompanyID", "CompanyName");
            ViewBag.ProjectSelect = new SelectList(await _projectRepo.List.ToListAsync(), "ProjectID", "ProjectName");
            return View(cd);
        }

        // POST: CompanyProject/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompanyProject cp)
        {
            if (id != cp.CompanyProjectID) NotFound();

            try
            {
                _cpRepo.Update(cp);
                TempData["status"] = "Şirket-Proje ilişkisi başarılı şekilde güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cp);
            }
        }

        // GET: CompanyProject/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null) NotFound();
            var cp = _cpRepo.List.FirstOrDefaultAsync(x => x.CompanyProjectID == id);
            if (cp == null) NotFound();
            return View(cp);
        }

        // POST: CompanyProject/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var cp = await _cpRepo.List.FirstOrDefaultAsync(_ => _.CompanyProjectID == id);
                if (cp == null) NotFound();
                _cpRepo.Delete(cp);
                TempData["status"] = "Şirket-Proje ilişkisi başarılı şekilde silindi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Silme işlemi başarısız!", ex);
            }
        }
    }
}
