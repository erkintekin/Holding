using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.Abstract;

namespace Holding.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICompanyService _companyService;
        private readonly IDepartmentService _departmentService;
        private readonly IRepository<Employee> _empRepo;

        public EmployeesController(IEmployeeService employeeService, ICompanyService companyService, IDepartmentService departmentService, IRepository<Employee> empRepo)
        {
            _employeeService = employeeService;
            _companyService = companyService;
            _departmentService = departmentService;
            _empRepo = empRepo;
        }
        // GET: EmployeesController
        public async Task<ActionResult> Index()
        {
            var employees = _empRepo.Include(c => c.Company, d => d.Department);
            return View(employees);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Companies = new SelectList(await _companyService.GetAllCompanies(), "CompanyID", "CompanyName");
            ViewBag.Department = new SelectList(await _departmentService.GetAllDepartments(), "DepartmentID", "DepartmentName");
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                _employeeService.CreateEmployee(employee);
                TempData["status"] = "Yeni çalışan başarılı şekilde eklendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employee);
            }
        }

        // GET: EmployeesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null) NotFound();
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null) NotFound("Çalışan bulunamadı");

            ViewBag.CompaniesSelect = new SelectList(await _companyService.GetAllCompanies(), "CompanyID", "CompanyName", employee.CompanyID);
            ViewBag.DepartmentSelect = new SelectList(await _departmentService.GetAllDepartments(), "DepartmentID", "DepartmentName", employee.DepartmentID);
            return View(employee);
        }
        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }
            try
            {
                _employeeService.UpdateEmployee(employee);
                TempData["status"] = "Çalışan başarılı şekilde güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employee);
            }
        }

        // GET: EmployeesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null) NotFound();
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null) NotFound();

            return View(employee);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var deleteEmployee = await _employeeService.GetEmployeeById(id);
                if (deleteEmployee == null) NotFound();

                _employeeService.RemoveEmployee(deleteEmployee);
                TempData["status"] = "Çalışan başarılı şekilde silindi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Silme işlemi başarısız!" + ex);
            }
        }
    }
}
