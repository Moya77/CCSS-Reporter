using CCSS_Reporter.DB;
using CCSS_Reporter.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CCSS_Reporter.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaAPIController : ControllerBase
    {
        private readonly ICommandRegClinica _ICommandRegClinica;
        private readonly IQueryGetClinica _IQueryGetClinica;
        public ClinicaAPIController(ICommandRegClinica ICommandRegClinica,
            IQueryGetClinica iQueryGetClinica)
        {
            _ICommandRegClinica = ICommandRegClinica;
            _IQueryGetClinica = iQueryGetClinica;
        }
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        [HttpPost]
        public IActionResult RegistrarClinica([FromBody] Clinica clinica)
        {
            _ICommandRegClinica.RegistrarClinica(clinica);
            return CreatedAtAction("", "");
        }

        [HttpGet("{id}")]
        public IActionResult GetRegistroClinica(string id)
        {
            return Ok(_IQueryGetClinica.ObtenerClinica(id));
        }


    }
}
