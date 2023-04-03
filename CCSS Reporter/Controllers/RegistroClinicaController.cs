using CCSS_Reporter.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CCSS_Reporter.Controllers
{
    public class RegistroClinicaController : Controller
    {
        // GET: RegistroClinicaController
        Clinica clinica = new Clinica();
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public RegistroClinicaController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration.GetValue<string>("APIUrl");
        }
        public ActionResult RegistroClinica()
        {
            return View(clinica);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarClinica(Clinica clinica)
        {

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_apiUrl}ClinicaAPI/", clinica);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return View("..\\RegistroPaciente\\RegistroPaciente", new Paciente());
        }

        [HttpPost]
        public async Task<IActionResult> SaltRegistro(string reason)
        {

            return Json(new { url = Url.Action("RegistroPaciente", "RegistroPaciente") });
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistroClinica(string id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}ClinicaAPI/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var clinica = JsonConvert.DeserializeObject<Clinica>(responseBody);
            return Ok(clinica);
        }


    }
}
