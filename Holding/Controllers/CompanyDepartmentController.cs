using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Holding.Controllers
{
    public class CompanyDepartmentController : Controller
    {
        private readonly IRepository<Company> _companyRepo;
        private readonly IRepository<Department> _departmentRepo;
        private readonly IRepository<CompanyDepartment> _cdRepo;

        public CompanyDepartmentController(IRepository<Company> companyRepo, IRepository<Department> departmentRepo, IRepository<CompanyDepartment> cdRepo)
        {
            _companyRepo = companyRepo;
            _departmentRepo = departmentRepo;
            _cdRepo = cdRepo;
        }
        // GET: CompanyDepartment
        public async Task<ActionResult> Index()
        {
            var cd = await _cdRepo.List.Include(c => c.Department).Include(c => c.Company).ToListAsync();
            return View(cd);
        }

        // GET: CompanyDepartment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyDepartment/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Companies = new SelectList(await _companyRepo.List.ToListAsync(), "CompanyID", "CompanyName");
            ViewBag.Departments = new SelectList(await _departmentRepo.List.ToListAsync(), "DepartmentID", "DepartmentName");
            return View();
        }

        // POST: CompanyDepartment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyDepartment cd)
        {
            try
            {
                _cdRepo.Create(cd);
                TempData["status"] = "Yeni Şirket-Departman ilişkisi başarılı şekilde eklendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cd);
            }
        }
        // GET: CompanyDepartment/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null) NotFound();
            var cd = await _cdRepo.List.FirstOrDefaultAsync(x => x.CompanyDepartmentID == id);
            ViewBag.CompanySelect = new SelectList(await _companyRepo.List.ToListAsync(), "CompanyID", "CompanyName", cd.Company);
            ViewBag.DepartmentSelect = new SelectList(await _departmentRepo.List.ToListAsync(), "DepartmentID", "DepartmentName", cd.Department);
            return View(cd);
        }

        // POST: CompanyDepartment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompanyDepartment cd)
        {
            if (id != cd.CompanyDepartmentID) NotFound();
            try
            {
                _cdRepo.Update(cd);
                TempData["status"] = "Şirket-Departman ilişkisi başarılı şekilde güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cd);
            }
        }

        // GET: CompanyDepartment/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null) NotFound();
            var cd = _cdRepo.List.FirstOrDefault(x => x.CompanyDepartmentID == id);
            if (cd == null) NotFound();
            return View(cd);
        }

        // POST: CompanyDepartment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var cd = _cdRepo.List.FirstOrDefault(x => x.CompanyDepartmentID == id);
                if (cd == null) NotFound("Silinecek öğe bulunamadı!");
                _cdRepo.Delete(cd);
                TempData["status"] = "Şirket-Departman ilişkisi başarılı şekilde silindi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Silme işlemi başarısız!", ex);
            }
        }
    }
}
