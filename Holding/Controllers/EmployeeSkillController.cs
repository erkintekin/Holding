using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Holding.Controllers
{
    public class EmployeeSkillController : Controller
    {
        private readonly IRepository<EmployeeSkill> _esRepo;
        private readonly IRepository<Employee> _empRepo;
        private readonly IRepository<Skill> _skRepo;

        public EmployeeSkillController(IRepository<EmployeeSkill> esRepo, IRepository<Employee> empRepo, IRepository<Skill> skRepo)
        {
            _esRepo = esRepo;
            _empRepo = empRepo;
            _skRepo = skRepo;
        }
        // GET: EmployeeSkillController
        public async Task<ActionResult> Index()
        {
            var es = await _esRepo.Include(e => e.Employee, p => p.Skill).ToListAsync();
            return View(es);
        }

        // GET: EmployeeSkillController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeSkillController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Employees = new SelectList(await _empRepo.List.ToListAsync(), "EmployeeID", "Name");
            ViewBag.Skills = new SelectList(await _skRepo.List.ToListAsync(), "SkillID", "SkillName");
            return View();
        }

        // POST: EmployeeSkillController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeSkill es)
        {
            try
            {
                _esRepo.Create(es);
                TempData["status"] = "Yeni Çalışan-Beceri ilişkisi başarılı şekilde eklendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(es);
            }
        }

        // GET: EmployeeSkillController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null) NotFound("id bulunamadı!");
            var es = await _esRepo.List.FirstOrDefaultAsync(x => x.EmployeeSkillID == id);
            ViewBag.EmployeeSelect = new SelectList(await _empRepo.List.ToListAsync(), "EmployeeID", "Name", es.EmployeeID);
            ViewBag.SkillSelect = new SelectList(await _skRepo.List.ToListAsync(), "SkillID", "SkillName", es.SkillID);
            return View(es);
        }

        // POST: EmployeeSkillController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeSkill es)
        {
            if (id != es.EmployeeSkillID) NotFound("Editlenecek item bulunamadı");

            try
            {
                _esRepo.Update(es);
                TempData["status"] = "Çalışan-Beceri ilişkisi başarılı şekilde güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(es);
            }
        }

        // GET: EmployeeSkillController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null) NotFound();
            var es = await _esRepo.List.FirstOrDefaultAsync(x => x.EmployeeSkillID == id);
            if (es == null) NotFound();
            return View(es);
        }

        // POST: EmployeeSkillController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]

        public async Task<ActionResult> DeleteConfirmedAsync(int id)
        {
            try
            {
                var es = await _esRepo.List.FirstOrDefaultAsync(x => x.EmployeeSkillID == id);
                if (es == null) NotFound();
                _esRepo.Delete(es);
                TempData["status"] = "Çalışan-Beceri ilişkisi başarılı şekilde silindi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Silme işlemi başarısız!", ex);
            }
        }
    }
}
