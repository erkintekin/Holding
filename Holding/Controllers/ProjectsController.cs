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
        private readonly ICompanyService _companyService;
        private readonly Context? _context;

        public ProjectsController(IProjectService projectService, ICompanyService companyService, Context? context)
        {
            _projectService = projectService;
            _companyService = companyService;
            _context = context;


            //if (!_context.Companies.Any())
            //{
            //    _context.Companies.AddRange(
            //        new Company
            //        {
            //            CompanyName = "Cengiz İnşaat"
            //        },
            //         new Company
            //         {
            //             CompanyName = "yemek.com"
            //         });

            //    _context.SaveChanges();
            //}

            //if (!_context.Projects.Any())
            //{

            //    _context.Projects.AddRange(
            //        new Project
            //        {
            //            ProjectName = "E-ticaret Sitesi Fullstack Projesi",
            //            ProjectNo = 17283,
            //            Proficiencies =  "C#,.NET,React,HTML/CSS",
            //            Price = 120000,
            //            Duration = 200,
            //            Employees = new List<Employee> { },
            //            CompanyID = 1,
            //        },
            //        new Project
            //        {
            //            ProjectName = "Yemek Sitesi Fullstack Projesi",
            //            ProjectNo = 17282,
            //            Proficiencies = "C#,.NET,React,HTML/CSS",
            //            Price = 150000,
            //            Duration = 200,
            //            Employees = new List<Employee> { },
            //            CompanyID = 2,
            //        }
            //        );
            //    _context.SaveChanges();
            //}
        }



        public async Task<ActionResult> Index()
        {

            var companies = await _companyService.GetAllCompanies();
            var projects = await _projectService.GetAllProjects();

            if (!projects.Any())
            {
                return RedirectToAction(nameof(Create));
            }


            return View(projects);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Project project)
        {
            try
            {
                var companies = await _companyService.GetAllCompanies();
                _projectService.CreateProject(project);

                if (project == null || project.CompanyID == null)
                {
                    return RedirectToAction(nameof(CompaniesController.Create));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
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
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var deletedProject = await _projectService.GetProjectById(id);

            if (deletedProject == null || id == null)
            {
                return NotFound();
            }
            try
            {
                _projectService.RemoveProject(deletedProject);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
