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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SkillsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SkillsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SkillsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
