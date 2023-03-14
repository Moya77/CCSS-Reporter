using CCSS_Reporter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Reporter.Controllers
{
    public class RegistroPacienteController : Controller
    {
        // GET: RegistroPacienteController
        Paciente paciente = new Paciente();

        public ActionResult RegistroPaciente()
        {
            return View(paciente);
        }

        // GET: RegistroPacienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistroPacienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistroPacienteController/Create
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

        // GET: RegistroPacienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistroPacienteController/Edit/5
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

        // GET: RegistroPacienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistroPacienteController/Delete/5
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
