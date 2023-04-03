using CCSS_Reporter.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CCSS_Reporter.Controllers
{
    public class RegistroPacienteController : Controller
    {
        Paciente paciente = new Paciente();

        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public RegistroPacienteController(HttpClient httpClient, IConfiguration configuration)
        {

            _httpClient = httpClient;
            _apiUrl = configuration.GetValue<string>("APIUrl");
        }

        public ActionResult RegistroPaciente()
        {
            return View(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPaciente(Paciente paciente)
        {

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_apiUrl}PacienteAPI/", paciente);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Inyeccion inyeccion = new();
            inyeccion.Id_paciente = paciente.Identificacion;
            return View("..\\Inyecciones\\Inyecciones", inyeccion);
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistroPaciente(string id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}PacienteAPI/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var paciente = JsonConvert.DeserializeObject<Paciente>(responseBody);
            return Ok(paciente);
        }

    }
}
