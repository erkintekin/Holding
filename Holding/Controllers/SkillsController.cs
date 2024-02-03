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

        public async Task<ActionResult> Index()
        {
            var skills = await _skillService.GetAllSkills();
            return View(skills);
        }


        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

   
        public ActionResult Create()
        {
            return View();
        }

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

 
        public async Task<ActionResult> Edit(int id)
        {
            var skill = await _skillService.GetSkillById(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

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


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Skill skill)
        {
            if (id != skill.SkillID)
            {
                return NotFound();
            }
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
                return NotFound(ex);

            }
           
        }
    }
}