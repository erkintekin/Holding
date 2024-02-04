using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Holding.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly Context _context;
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(Context context, IDepartmentService departmentService)
        {
            _context = context;
            _departmentService = departmentService;
            if (!_context.Departments.Any())
            {
                _context.Departments.AddRange(
                    new Department() { DepartmentName = "İnsan Kaynakları", DepartmentInfo = "falan filan departmanı filan açıklaması işte.", HeadCount = 100, Quota = 150, Employees = new List<Employee>() },
                    new Department() { DepartmentName = "Falan Departman", DepartmentInfo = "falan filan departmanı filan açıklaması işte.", HeadCount = 100, Quota = 150, Employees = new List<Employee>() },
                    new Department() { DepartmentName = "Filan Departman", DepartmentInfo = "falan filan departmanı filan açıklaması işte.", HeadCount = 100, Quota = 150, Employees = new List<Employee>() }
                    );
                _context.SaveChanges();
            }
        }
        // GET: DepartmentsController
        public async Task<ActionResult> Index()
        {
            var departments = await _departmentService.GetAllDepartments();
            return View(departments);
        }

        // GET: DepartmentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try
            {
                _departmentService.CreateDepartment(department);
                TempData["status"] = "Yeni departman başarılı şekilde eklendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(department);
            }
        }

        // GET: DepartmentsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var department = await _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound("Id bulunamadı");
            }
            return View(department);
        }

        // POST: DepartmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department department)
        {
            if (id != department.DepartmentID)
            {
                return NotFound();
            }
            try
            {
                _departmentService.UpdateDepartment(department);
                TempData["status"] = "Departman başarılı şekilde güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(department);
            }
        }

        // GET: DepartmentsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = await _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: DepartmentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Department department)
        {
            try
            {
                var deleteDepartment = await _departmentService.GetDepartmentById(id);
                if (deleteDepartment == null)
                {
                    return NotFound();
                }
                _departmentService.RemoveDepartment(deleteDepartment);
                TempData["status"] = "Departman başarılı şekilde silindi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Silme işlemi başarısız!" + ex);
            }
        }
    }
}
