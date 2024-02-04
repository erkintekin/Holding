using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace Holding.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly Context? _context;

        public ProjectsController(IProjectService projectService, Context? context)
        {
            _projectService = projectService;
            _context = context;


            if (!_context.Companies.Any())
            {
                _context.Companies.AddRange(
                    new Company
                    {
                        CompanyName = "Cengiz İnşaat"
                    },
                     new Company
                     {
                         CompanyName = "yemek.com"
                     });

                _context.SaveChanges();
            }

            if (!_context.Projects.Any())
            {

                _context.Projects.AddRange(
                    new Project
                    {
                        ProjectName = "E-ticaret Sitesi Fullstack Projesi",
                        ProjectNo = 17283,
                        Proficiencies =  "C#,.NET,React,HTML/CSS",
                        Price = 120000,
                        Duration = 200,
                        Employees = new List<Employee> { },
                        CompanyID = 1,
                    },
                    new Project
                    {
                        ProjectName = "Yemek Sitesi Fullstack Projesi",
                        ProjectNo = 17282,
                        Proficiencies = "C#,.NET,React,HTML/CSS",
                        Price = 150000,
                        Duration = 200,
                        Employees = new List<Employee> { },
                        CompanyID = 2,
                    }
                    );
                _context.SaveChanges();
            }
        }



        public async Task<IActionResult> Index()
        {

            var projects = await _projectService.GetAllProjects();

            var companyName = await _context.Projects.Include(p => p.Company).ToListAsync();

            return View(projects);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {

            try
            {
                _projectService.CreateProject(project);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(project);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {

            var project = await _projectService.GetProjectById(id);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        public async Task<IActionResult> Edit(int id, Project project)
        {

            if (id != project.ProjectID)
            {
                return NotFound();
            }
            try
            {
                _projectService.UpdateProject(project);
                return View(nameof(Index));
            }
            catch
            {
                return View(project);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var project = await _projectService.GetProjectById(id);

            if (id != project.ProjectID)
            {
                return NotFound();
            }

            return View(project);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Project project)
        {

            var deletedProject = await _projectService.GetProjectById(id);

            if (deletedProject == null)
            {
                return NotFound();
            }
            try
            {
                _projectService.RemoveProject(project);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
