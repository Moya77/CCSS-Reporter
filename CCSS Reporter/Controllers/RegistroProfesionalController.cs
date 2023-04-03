using CCSS_Reporter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace CCSS_Reporter.Controllers
{
    public class RegistroProfesionalController : Controller
    {
        // GET: RegistroProfesionalController
        Profesional profesional = new Profesional();
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        private readonly IMemoryCache _memoryCache;


        public RegistroProfesionalController(HttpClient httpClient, IConfiguration configuration,
                                             IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _apiUrl = configuration.GetValue<string>("APIUrl");
            _memoryCache = memoryCache;
        }


        public ActionResult RegistroProfesional()
        {
            return View(profesional);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarProfesional(Profesional profesional)
        {

            profesional.NumeroRegistro1 = "";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_apiUrl}ProfesionalAPI/", profesional);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            if (responseBody.Length > 0)
            {
                profesional.NumeroRegistro1 = responseBody.ToString();
                HttpResponseMessage responseMail = await _httpClient.PostAsJsonAsync($"{_apiUrl}EmailService/SendEmail/", profesional);
                responseMail.EnsureSuccessStatusCode();

            }
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                Priority = CacheItemPriority.NeverRemove
            };

            _memoryCache.Set("ProfesionalObject", profesional, cacheEntryOptions);

            return View("..\\RegistroClinica\\RegistroClinica", new Clinica());
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistroProfesional(string id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}ProfesionalAPI/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var profesional = JsonConvert.DeserializeObject<Profesional>(responseBody);
            return Ok(profesional);
        }

    }
}
