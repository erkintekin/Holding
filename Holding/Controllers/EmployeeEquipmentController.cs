using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Holding.Controllers
{
    public class EmployeeEquipmentController : Controller
    {
        private readonly IRepository<EmployeeEquipment> _eeRepo;
        private readonly IRepository<Employee> _employeeRepo;
        private readonly IRepository<Equipment> _equipmentRepo;

        public EmployeeEquipmentController(IRepository<EmployeeEquipment> eeRepo, IRepository<Employee> employeeRepo, IRepository<Equipment> equipmentRepo)
        {
            _eeRepo = eeRepo;
            _employeeRepo = employeeRepo;
            _equipmentRepo = equipmentRepo;
        }
        // GET: EmployeeEquipmentController
        public async Task<ActionResult> Index()
        {
            var ee = await _eeRepo.Include(e => e.Equipment, ee => ee.Employee).ToListAsync();
            return View(ee);
        }
        // GET: EmployeeEquipmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeEquipmentController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Employees = new SelectList(await _employeeRepo.List.ToListAsync(), "EmployeeID", "Name");
            ViewBag.Equipments = new SelectList(await _equipmentRepo.List.ToListAsync(), "EquipmentID", "EquipmentName");
            return View();
        }

        // POST: EmployeeEquipmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeEquipment ee)
        {
            try
            {
                _eeRepo.Create(ee);
                TempData["status"] = "Yeni Çalışan-Ekipman ilişkisi başarılı şekilde eklendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(ee);
            }
        }

        // GET: EmployeeEquipmentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null) NotFound("id bulunamadı!");
            var ee = await _eeRepo.List.FirstOrDefaultAsync(x => x.EmployeeEquipmentID == id);
            ViewBag.EmployeeSelect = new SelectList(await _employeeRepo.List.ToListAsync(), "EmployeeID", "Name", ee.EmployeeID);
            ViewBag.EquipmentSelect = new SelectList(await _equipmentRepo.List.ToListAsync(), "EquipmentID", "EquipmentName", ee.EquipmentID);
            return View(ee);
        }

        // POST: EmployeeEquipmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeEquipment ee)
        {
            if (id != ee.EmployeeEquipmentID) NotFound("Editlenecek item bulunamadı");

            try
            {
                _eeRepo.Update(ee);
                TempData["status"] = "Çalışan-Ekipman ilişkisi başarılı şekilde güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(ee);
            }
        }

        // GET: EmployeeEquipmentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null) NotFound();
            var ee = await _eeRepo.List.FirstOrDefaultAsync(x => x.EmployeeEquipmentID == id);
            if (ee == null) NotFound();
            return View(ee);
        }

        // POST: EmployeeEquipmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var ee = await _eeRepo.List.FirstOrDefaultAsync(x => x.EmployeeEquipmentID == id);
                if (ee == null) NotFound();
                _eeRepo.Delete(ee);
                TempData["status"] = "Çalışan-Ekipman ilişkisi başarılı şekilde silindi!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Silme işlemi başarısız!", ex);
            }
        }
    }
}
