using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;

namespace Holding.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        // GET: SkillsController
        public async Task<ActionResult> Index()
        {
            var skills = await _skillService.GetAllSkills();
            return View(skills);
        }

        // GET: SkillsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SkillsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkillsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Skill skill)
        {
            try
            {
                _skillService.CreateSkill(skill);
                TempData["status"] = "Yeni beceri başarılı şekilde eklendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(skill);
            }
        }

        // GET: SkillsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var skill = await _skillService.GetSkillById(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        // POST: SkillsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Skill skill)
        {
            if (id != skill.SkillID)
            {
                return NotFound();
            }
            try
            {
                _skillService.UpdateSkill(skill);
                TempData["status"] = "Beceri başarılı bir şekilde güncellendi.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(skill);
            }
        }

        // GET: SkillsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var skill = await _skillService.GetSkillById(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        // POST: SkillsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {

                //deneme
                var deleteSkill = await _skillService.GetSkillById(id);
                if (deleteSkill == null)
                {
                    return NotFound();
                }
                _skillService.RemoveSkill(deleteSkill);
                TempData["status"] = "Beceri başarılı bir şekilde silindi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Silme işlemi başarısız!" + ex);
            }
        }
    }
}
