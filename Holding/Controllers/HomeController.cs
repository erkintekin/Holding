using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Holding.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Holding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
            if (!_context.Customers.Any())
            {
                _context.Customers.AddRange(
                     new Customer { CustomerName = "H şirketi" },
                     new Customer { CustomerName = "A şirketi" },
                     new Customer { CustomerName = "B şirketi" },
                     new Customer { CustomerName = "C şirketi" }
                     );
                _context.SaveChanges();
            }
            if (!_context.Departments.Any())
            {
                _context.Departments.AddRange(
                    new Department() { DepartmentName = "İnsan Kaynakları", HeadCount = 100, Quota = 150, Employees = new List<Employee>() },
                    new Department() { DepartmentName = "Falan Departman", HeadCount = 100, Quota = 150, Employees = new List<Employee>() },
                    new Department() { DepartmentName = "Filan Departman", HeadCount = 100, Quota = 150, Employees = new List<Employee>() }
                    );
                _context.SaveChanges();
            }
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
            if (!_context.Skills.Any())
            {
                _context.Skills.AddRange(
                     new Skill { SkillName = "C#", SkillDescription = "Çok iyi biliyorum." },
                     new Skill { SkillName = "Python", SkillDescription = "İdare edecek kadar biliyorum" }
                     );
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
            if (!_context.Equipments.Any())
            {
                _context.Equipments.AddRange(
                    new Equipment { EquipmentName = "Lenovo Laptop" },
                    new Equipment { EquipmentName = "Mouse" },
                    new Equipment { EquipmentName = "Laptop Case" }
                    );
                _context.SaveChanges();
            }
            if (!_context.Projects.Any())
            {

                _context.Projects.AddRange(
                    new Project
                    {
                        CustomerID = 1,
                        ProjectName = "E-ticaret Sitesi Fullstack Projesi",
                        ProjectNo = 17283,
                        Proficiencies = "C#,.NET,React,HTML/CSS",
                        Price = 120000,
                        Duration = 200,
                    },
                    new Project
                    {
                        CustomerID = 2,
                        ProjectName = "Yemek Sitesi Fullstack Projesi",
                        ProjectNo = 17282,
                        Proficiencies = "C#,.NET,React,HTML/CSS",
                        Price = 150000,
                        Duration = 200,
                    }
                    );
                _context.SaveChanges();
            }

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
