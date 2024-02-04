using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Abstract;

namespace Holding.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly Context _context;
        private readonly IEmployeeService _employeeService;
        private readonly IRepository<Employee> _employeeRepo;

        public EmployeesController(Context context, IEmployeeService employeeService, IRepository<Employee> employeeRepo)
        {
            _context = context;
            _employeeService = employeeService;
            _employeeRepo = employeeRepo;
            if (!_context.Companies.Any())
            {
                _context.Companies.AddRange(
                    new Company
                    {
                        CompanyName = "Cengiz İnşaat"
                    },
                     new Company
                     {
                         CompanyName = "Kolin Holding"
                     });

                _context.SaveChanges();
            }
            if (!_context.Employees.Any())
            {
                _context.Employees.AddRange(
                    new Employee() { TCKN = "12345678912", RegNo = 12, Name = "Erkin", Surname = "Tekin", Mail = "et@gmail.com", Address = "Manisa", Phone = "987654245", Title = "Yer Bilimci", Wage = 50000, StartDate = DateTime.Now, Birthday = new DateTime(1997, 10, 15), Image = "", DepartmentID = 1, CompanyID = 1 },
                    new Employee() { TCKN = "12345678912", RegNo = 22, Name = "Cengizhan", Surname = "Şahin", Mail = "cs@gmail.com", Address = "Trabzon", Phone = "987654245", Title = "Mühendis", Wage = 30000, StartDate = DateTime.Now, Birthday = new DateTime(1997, 10, 15), Image = "", DepartmentID = 2, CompanyID = 2 }
                    );
                _context.SaveChanges();
            }
        }
        // GET: EmployeesController
        public ActionResult Index()
        {
            var employees = _employeeRepo.List.Include(c => c.Company).Include(d => d.Department).ToList();
            //var employees = await _context.Employees.Include(c => c.Company).ThenInclude(d => d.Projects).ToListAsync();
            //var employees = await _employeeService.GetAllEmployees();
            return View(employees);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
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
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound("Çalışan id si bulunamadı");
            }
            return View(employee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound("id bulunamadı");
            }
            try
            {
                _employeeService.UpdateEmployee(employee);
                TempData["status"] = "Çalışan başarılı şekilde güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound("id bulunamadı");
            }
            var employee = await _employeeService.GetEmployeeById(id);
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
                var employee = await _employeeService.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                _employeeService.RemoveEmployee(employee);
                TempData["status"] = "Çalışan başarılı şekilde silindi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
