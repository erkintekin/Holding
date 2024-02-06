using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holding.Controllers
{
    public class PayrollsController : Controller
    {
        // GET: PayrollController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PayrollController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PayrollController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PayrollController/Create
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

        // GET: PayrollController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PayrollController/Edit/5
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

        // GET: PayrollController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PayrollController/Delete/5
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
