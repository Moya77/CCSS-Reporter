using CCSS_Reporter.DB;
using CCSS_Reporter.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CCSS_Reporter.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteAPIController : ControllerBase
    {

        private readonly IQueryGetPaciente _IQueryGetPaciente;
        private readonly ICommandRegPaciente _ICommandRegPaciente;

        public PacienteAPIController(ICommandRegPaciente ICommandRegPaciente,
            IQueryGetPaciente IQueryGetPaciente)
        {
            _ICommandRegPaciente = ICommandRegPaciente;
            _IQueryGetPaciente = IQueryGetPaciente;
        }
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        [HttpPost]
        public IActionResult RegistrarPaciente([FromBody] Paciente paciente)
        {


            _ICommandRegPaciente.RegistrarPaciente(paciente);
            return CreatedAtAction("", "");
        }

        [HttpGet("{id}")]
        public IActionResult GetRegistroPaciente(string id)
        {
            return Ok(_IQueryGetPaciente.ObtenerPaciente(id));
        }


    }
}
