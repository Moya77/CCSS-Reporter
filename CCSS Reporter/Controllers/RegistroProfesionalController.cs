using CCSS_Reporter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Reporter.Controllers
{
    public class RegistroProfesionalController : Controller
    {
        // GET: RegistroProfesionalController
        Profesional profesional = new Profesional();
        public ActionResult RegistroProfesional()
        {
            return View(profesional);
        }

        // GET: RegistroProfesionalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistroProfesionalController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult RegistrarProfesional(Profesional profesional)
        {

            return View("..\\RegistroClinica\\RegistroClinica",new Clinica());
        }

        // POST: RegistroProfesionalController/Create
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

        // GET: RegistroProfesionalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistroProfesionalController/Edit/5
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

        // GET: RegistroProfesionalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistroProfesionalController/Delete/5
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
