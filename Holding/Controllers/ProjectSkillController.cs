using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Holding.Controllers
{
    public class ProjectSkillController : Controller
    {
        private readonly IRepository<ProjectSkill> _psRepo;
        private readonly IRepository<Project> _prjRepo;
        private readonly IRepository<Skill> _skRepo;

        public ProjectSkillController(IRepository<ProjectSkill> psRepo, IRepository<Project> prjRepo, IRepository<Skill> skRepo)
        {
            _psRepo = psRepo;
            _prjRepo = prjRepo;
            _skRepo = skRepo;
        }
        // GET: ProjectSkillController
        public async Task<ActionResult> Index()
        {
            var ps = await _psRepo.Include(p => p.Project, s => s.Skill).ToListAsync();
            return View(ps);
        }

        // GET: ProjectSkillController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjectSkillController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Projects = new SelectList(await _prjRepo.List.ToListAsync(), "ProjectID", "ProjectName");
            ViewBag.Skills = new SelectList(await _skRepo.List.ToListAsync(), "SkillID", "SkillName");
            return View();
        }

        // POST: ProjectSkillController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectSkill ps)
        {
            try
            {
                _psRepo.Create(ps);
                TempData["status"] = "Yeni Proje-Beceri ilişkisi başarılı şekilde eklendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(ps);
            }
        }

        // GET: ProjectSkillController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null) NotFound("id bulunamadı!");
            var ps = await _psRepo.List.FirstOrDefaultAsync(x => x.ProjectSkillID == id);
            ViewBag.ProjectSelect = new SelectList(await _prjRepo.List.ToListAsync(), "ProjectID", "ProjectName", ps.ProjectID);
            ViewBag.SkillSelect = new SelectList(await _skRepo.List.ToListAsync(), "SkillID", "SkillName", ps.SkillID);
            return View();
        }

        // POST: ProjectSkillController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectSkill ps)
        {
            if (id != ps.ProjectSkillID) NotFound("Editlenecek item bulunamadı");

            try
            {
                _psRepo.Update(ps);
                TempData["status"] = "Proje-Beceri ilişkisi başarılı şekilde güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(ps);
            }
        }

        // GET: ProjectSkillController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null) NotFound();
            var ps = await _psRepo.List.FirstOrDefaultAsync(x => x.ProjectSkillID == id);
            if (ps == null) NotFound();
            return View(ps);
        }

        // POST: ProjectSkillController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<ActionResult> DeleteConfirmedAsync(int id)
        {
            try
            {
                var ps = await _psRepo.List.FirstOrDefaultAsync(x => x.ProjectSkillID == id);
                if (ps == null) NotFound();
                _psRepo.Delete(ps);
                TempData["status"] = "Proje-Beceri ilişkisi başarılı şekilde silindi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Silme işlemi başarısız!", ex);
            }
        }
    }
}
