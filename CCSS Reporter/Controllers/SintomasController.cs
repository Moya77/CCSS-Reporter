using CCSS_Reporter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace CCSS_Reporter.Controllers
{
    public class SintomasController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        private readonly IMemoryCache _memoryCache;
        public ActionResult Sintomas()
        {
            return View(new SintomasPaciente());
        }

        public SintomasController(HttpClient httpClient, IConfiguration configuration,
                                  IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _apiUrl = configuration.GetValue<string>("APIUrl");
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarSintomasPaciente(SintomasPaciente sintomas)
        {
            Reporte reporte = new Reporte();
            Profesional pro;
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_apiUrl}SintomasAPI/", sintomas);
            response.EnsureSuccessStatusCode();



            var responsePaciente = await _httpClient.GetAsync($"{_apiUrl}PacienteAPI/{sintomas.Id_paciente1}");
            responsePaciente.EnsureSuccessStatusCode();
            var responseBodyPaciente = await responsePaciente.Content.ReadAsStringAsync();
            reporte.Paciente = JsonConvert.DeserializeObject<Paciente>(responseBodyPaciente);


            _memoryCache.TryGetValue("ProfesionalObject", out pro);
            reporte.Profesional = pro;

            reporte.fechaAtencion = DateTime.Now;

            HttpResponseMessage responseSendMail = await _httpClient.PostAsJsonAsync($"{_apiUrl}EmailService/SendEmailReport/", reporte);
            responseSendMail.EnsureSuccessStatusCode();

            return View("..\\Report\\Report", reporte);
        }


    }
}
