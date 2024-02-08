using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Holding.Controllers
{
    public class EmployeeProjectController : Controller
    {
        private readonly IRepository<EmployeeProject> _epRepo;
        private readonly IRepository<Employee> _empRepo;
        private readonly IRepository<Project> _prjRepo;

        public EmployeeProjectController(IRepository<EmployeeProject> epRepo, IRepository<Employee> empRepo, IRepository<Project> prjRepo)
        {
            _epRepo = epRepo;
            _empRepo = empRepo;
            _prjRepo = prjRepo;
        }
        // GET: EmployeeProjectController
        public async Task<ActionResult> Index()
        {
            var ep = await _epRepo.Include(e => e.Employee, p => p.Project).ToListAsync();
            return View(ep);
        }

        // GET: EmployeeProjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeProjectController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Employees = new SelectList(await _empRepo.List.ToListAsync(), "EmployeeID", "Name");
            ViewBag.Projects = new SelectList(await _prjRepo.List.ToListAsync(), "ProjectID", "ProjectName");
            return View();
        }

        // POST: EmployeeProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeProject ep)
        {
            try
            {
                _epRepo.Create(ep);
                TempData["status"] = "Yeni Çalışan-Proje ilişkisi başarılı şekilde eklendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(ep);
            }
        }

        // GET: EmployeeProjectController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null) NotFound("id bulunamadı!");
            var ep = await _epRepo.List.FirstOrDefaultAsync(x => x.EmployeeProjectID == id);
            ViewBag.EmployeeSelect = new SelectList(await _empRepo.List.ToListAsync(), "EmployeeID", "Name", ep.EmployeeID);
            ViewBag.ProjectSelect = new SelectList(await _prjRepo.List.ToListAsync(), "ProjectID", "ProjectName", ep.ProjectID);
            return View(ep);
        }

        // POST: EmployeeProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeProject ep)
        {
            if (id != ep.EmployeeProjectID) NotFound("Editlenecek item bulunamadı");

            try
            {
                _epRepo.Update(ep);
                TempData["status"] = "Çalışan-Proje ilişkisi başarılı şekilde güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(ep);
            }
        }

        // GET: EmployeeProjectController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null) NotFound();
            var ep = await _epRepo.List.FirstOrDefaultAsync(x => x.EmployeeProjectID == id);
            if (ep == null) NotFound();
            return View(ep);
        }

        // POST: EmployeeProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var ep = await _epRepo.List.FirstOrDefaultAsync(x => x.EmployeeProjectID == id);
                if (ep == null) NotFound();
                _epRepo.Delete(ep);
                TempData["status"] = "Çalışan-Proje ilişkisi başarılı şekilde silindi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Silme işlemi başarısız!", ex);
            }
        }
    }
}
