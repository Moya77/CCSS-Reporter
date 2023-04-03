using CCSS_Reporter.DB;
using CCSS_Reporter.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CCSS_Reporter.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class SintomasAPIController : ControllerBase
    {
        private readonly ICommandRegSintomasPaciente _ICommandRegSintomasPaciente;
        public SintomasAPIController(ICommandRegSintomasPaciente ICommandRegSintomasPaciente)
        {
            _ICommandRegSintomasPaciente = ICommandRegSintomasPaciente;
        }
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        [HttpPost]
        public IActionResult RegistrarSintomasPaciente([FromBody] SintomasPaciente sintomas)
        {
            _ICommandRegSintomasPaciente.RegistrarSintomasPaciente(sintomas);
            return CreatedAtAction("", "");
        }

        [HttpGet("{id}")]
        public IActionResult GetRegistroSintomasPaciente(string id)
        {
            return Ok("_IQueryGetClinica.ObtenerClinica(id)");
        }


    }
}
