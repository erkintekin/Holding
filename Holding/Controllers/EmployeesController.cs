using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Holding.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly Context _context;
        private readonly IEmployeeService _employeeService;

        public EmployeesController(Context context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;

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
        public async Task<ActionResult> Index()
        {
            var employees = await _context.Employees.Include(c => c.Company).Include(d => d.Department).ToListAsync();
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
        public ActionResult Create(IFormCollection collection)
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

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
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

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
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
