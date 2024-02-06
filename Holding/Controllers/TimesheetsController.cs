using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holding.Controllers
{
    public class TimesheetsController : Controller
    {
        // GET: TimesheetsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TimesheetsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TimesheetsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimesheetsController/Create
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

        // GET: TimesheetsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TimesheetsController/Edit/5
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

        // GET: TimesheetsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TimesheetsController/Delete/5
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
