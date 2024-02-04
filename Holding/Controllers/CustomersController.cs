using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holding.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly Context _context;

        public CustomersController(ICustomerService customerService, Context context)
        {
            _customerService = customerService;
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
        }
        // GET: CustomerController
        public async Task<ActionResult> Index()
        {
            var customers = await _customerService.GetAllCustomers();
            return View(customers);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _customerService.CreateCustomer(customer);
                TempData["status"] = "Yeni müşteri başarılı şekilde eklendi!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound("customer id bulunamadı");
            }
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.CustomerID)
            {
                return NotFound();
            }
            try
            {
                _customerService.UpdateCustomer(customer);
                TempData["status"] = "Müşteri başarılı şekilde güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: CustomerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var deleteCustomer = await _customerService.GetCustomerById(id);
                if (deleteCustomer == null)
                {
                    return NotFound();
                }
                _customerService.RemoveCustomer(deleteCustomer);
                TempData["status"] = "Müşteri başarılı şekilde silindi!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
