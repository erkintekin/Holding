using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace Holding.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ICustomerService _customerService;

        public ProjectsController(IProjectService projectService, ICustomerService customerService)
        {
            _projectService = projectService;
            _customerService = customerService;
        }
        public async Task<ActionResult> Index()
        {
            var projects = await _projectService.GetAllProjects();
            return View(projects);
        }
        public async Task<ActionResult> Create()
        {
            ViewBag.Customers = new SelectList(await _customerService.GetAllCustomers(), "CustomerID", "CustomerName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Project project)
        {
            try
            {
                _projectService.CreateProject(project);
                TempData["status"] = "Yeni proje başarılı şekilde eklendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(project);
            }


        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) NotFound();
            var project = await _projectService.GetProjectById(id);
            if (project == null) NotFound("Proje bulunamadı");

            ViewBag.CustomerSelect = new SelectList(await _customerService.GetAllCustomers(), "CustomerID", "CustomerName", project.ProjectID);

            return View(project);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Project project)
        {

            if (id != project.ProjectID) NotFound();
            try
            {
                _projectService.UpdateProject(project);
                TempData["status"] = "Proje başarılı şekilde güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(project);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) NotFound();
            var project = await _projectService.GetProjectById(id);
            if (project == null) NotFound();
            return View(project);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var deletedProject = await _projectService.GetProjectById(id);
                if (deletedProject == null) NotFound("Silinecek Proje bulunamadı");
                _projectService.RemoveProject(deletedProject);
                TempData["status"] = "Proje başarılı şekilde silindi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Silme işlemi başarısız!" + ex);
            }
        }
    }
}
