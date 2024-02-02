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
        private readonly Context _context;

        public SkillsController(ISkillService skillService, Context context)
        {
            _skillService = skillService;
            _context = context;
            if (!_context.Skills.Any())
            {
                _context.Skills.AddRange(
                     new Skill { SkillName = "C#", SkillDescription = "Çok iyi biliyorum." },
                     new Skill { SkillName = "Python", SkillDescription = "İdare edecek kadar biliyorum" }
                     );
                _context.SaveChanges();
            }
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
        public ActionResult Edit(int id, Skill skill)
        {
            if (id != skill.SkillID)
            {
                return NotFound();
            }
            try
            {
                _skillService.UpdateSkill(skill);
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
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<ActionResult> DeleteSkill(int id)
        {
            
=======
        public async Task<ActionResult> Delete(int id, Skill skill)
        {
            if (id != skill.SkillID)
            {
                return NotFound();
            }
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
            try
            {
                var deleteSkill = await _skillService.GetSkillById(id);
                if (deleteSkill == null)
                {
                    return NotFound();
                }
                _skillService.RemoveSkill(deleteSkill);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
<<<<<<< HEAD
                return NotFound(ex);
=======
                return View(skill);
>>>>>>> 21d2f011126ba6a75584e3b7181e2075de6c8aa7
            }
           
        }
    }
}