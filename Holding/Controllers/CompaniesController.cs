using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Holding.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IProjectService _projectService;
        private readonly Context _context;

        public CompaniesController(ICompanyService companyService, IProjectService projectService, Context context)
        {
            _companyService = companyService;
            _projectService = projectService;
            _context = context;
        }



        public async Task<ActionResult> Index()
        {

            var companies = await _companyService.GetAllCompanies();
            var projects = await _projectService.GetAllProjects();

            if (!companies.Any())
            {
                return RedirectToAction(nameof(Create));
            }

            return View(companies);
        }


        public ActionResult Create()
        {
            ViewBag.Companies = _context.Companies.ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {

            try
            {
                _companyService.CreateCompany(company);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(company);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {

            var company = await _companyService.GetCompanyById(id);

            if (company == null)
            {
                return NotFound("Lütfen geçerli bir Şirket seçiniz");
            }

            return View(company);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Company company)
        {

            if (id != company.CompanyID)
            {
                return NotFound("Bu ID'ye ait bir şirket bulunamadı!");
            }
            try
            {
                _companyService.UpdateCompany(company);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(company);
            }
        }


        public async Task<ActionResult> Delete(int id)
        {
            var company = await _companyService.GetCompanyById(id);

            if (company == null)
            {
                return NotFound("Lütfen geçerli bir Şirket seçiniz");
            }

            return View(company);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var deletedCompany = await _companyService.GetCompanyById(id);

            if (deletedCompany == null || id == null)
            {
                return NotFound("Lütfen geçerli bir Şirket seçiniz");
            }
            try
            {
                _companyService.RemoveCompany(deletedCompany);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
