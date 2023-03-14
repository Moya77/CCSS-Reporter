using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Reporter.Controllers
{
    public class InyeccionesController : Controller
    {
        // GET: InyeccionesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InyeccionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InyeccionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InyeccionesController/Create
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

        // GET: InyeccionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InyeccionesController/Edit/5
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

        // GET: InyeccionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InyeccionesController/Delete/5
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
