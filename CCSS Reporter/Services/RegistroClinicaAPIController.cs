using CCSS_Reporter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CCSS_Reporter.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroClinicaAPIController : ControllerBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        [HttpPost]
        public IActionResult RegistrarClinica([FromBody] Clinica clinica)
        {
           
            return CreatedAtAction("","");
        }

        [HttpGet]
        public IActionResult test()
        {

            return CreatedAtAction("", "");
        }


    }
}
