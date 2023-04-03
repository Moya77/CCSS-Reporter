using CCSS_Reporter.Models;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Reporter.Controllers
{
    public class InyeccionesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public InyeccionesController(HttpClient httpClient, IConfiguration configuration)
        {

            _httpClient = httpClient;
            _apiUrl = configuration.GetValue<string>("APIUrl");
        }

        public ActionResult Inyecciones()
        {
            return View(new Inyeccion());
        }




        [HttpPost]
        public async Task<IActionResult> RegistrarInyeccion(Inyeccion inyeccion)
        {

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_apiUrl}InyeccionAPI/", inyeccion);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            SintomasPaciente sintomas = new();
            sintomas.Id_paciente1 = inyeccion.Id_paciente;
            return View("..\\Sintomas\\Sintomas", sintomas);
        }



    }
}
