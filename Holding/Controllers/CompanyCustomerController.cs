using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Holding.Controllers
{
    public class CompanyCustomerController : Controller
    {
        private readonly IRepository<CompanyCustomer> _ccrepository;
        private readonly IRepository<Company> _companyRepo;
        private readonly IRepository<Customer> _customerRepo;

        public CompanyCustomerController(IRepository<CompanyCustomer> ccrepository, IRepository<Company> companyRepo, IRepository<Customer> customerRepo)
        {
            _ccrepository = ccrepository;
            _companyRepo = companyRepo;
            _customerRepo = customerRepo;
        }
        // GET: CompanyCustomerController
        public async Task<ActionResult> Index()
        {
            var cc = await _ccrepository.List.Include(c => c.Company).Include(c => c.Customer).ToListAsync();
            return View(cc);
        }

        // GET: CompanyCustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyCustomerController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Companies = new SelectList(await _companyRepo.List.ToListAsync(), "CompanyID", "CompanyName");
            ViewBag.Customers = new SelectList(await _customerRepo.List.ToListAsync(), "CustomerID", "CustomerName");
            return View();
        }

        // POST: CompanyCustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyCustomer cc)
        {
            try
            {
                _ccrepository.Create(cc);
                TempData["status"] = "Yeni Şirket-Müşteri ilişkisi başarılı şekilde eklendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cc);
            }
        }

        // GET: CompanyCustomerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound("Geçersiz ID girişi");
            }
            var cc = await _ccrepository.List.FirstOrDefaultAsync(c => c.CompanyCustomerID == id);
            ViewBag.CompanySelect = new SelectList(await _companyRepo.List.ToListAsync(), "CompanyID", "CompanyName", cc.CompanyID);
            ViewBag.CustomersSelect = new SelectList(await _customerRepo.List.ToListAsync(), "CustomerID", "CustomerName", cc.CustomerID);
            return View(cc);
        }

        // POST: CompanyCustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompanyCustomer cc)
        {
            if (id != cc.CompanyCustomerID)
            {
                return NotFound();
            }
            try
            {
                _ccrepository.Update(cc);
                TempData["status"] = "Şirket-Müşteri ilişkisi başarılı şekilde güncellendi!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cc);
            }
        }

        // GET: CompanyCustomerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound("Geçersiz ID");
            }
            var cc = await _ccrepository.List.FirstOrDefaultAsync(c => c.CompanyCustomerID == id);
            if (cc == null)
            {
                return NotFound("Silinecek ID bulunamadı!");
            }
            return View(cc);
        }

        // POST: CompanyCustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var cc = await _ccrepository.List.FirstOrDefaultAsync(c => c.CompanyCustomerID == id);
                _ccrepository.Delete(cc);
                TempData["status"] = "Şirket-Müşteri ilişkisi başarılı şekilde silindi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Silme işlemi başarısız!", ex);
            }
        }
    }
}
