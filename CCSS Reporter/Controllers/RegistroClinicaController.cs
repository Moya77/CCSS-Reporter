using CCSS_Reporter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;

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
           
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_apiUrl}RegistroClinicaAPI/", clinica);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            // parse JSON response
            return View(clinica);
        }


    }
}
