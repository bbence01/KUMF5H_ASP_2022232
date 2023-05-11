using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KUMF5H_ASP_2022232.Controllers
{
    public class FoodrequestController : Controller
    {
        // GET: FoodrequestController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FoodrequestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FoodrequestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodrequestController/Create
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

        // GET: FoodrequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FoodrequestController/Edit/5
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

        // GET: FoodrequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FoodrequestController/Delete/5
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
