using CCSS_Reporter.DB;
using CCSS_Reporter.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CCSS_Reporter.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionalAPIController : ControllerBase
    {
        private readonly ICommandRegProfesional _ICommandRegProfesional;
        private readonly IQueryGetProfesional _IQueryGetProfesional;

        public ProfesionalAPIController(ICommandRegProfesional ICommandRegProfesional,
                                                IQueryGetProfesional iQueryGetProfesional)
        {
            _ICommandRegProfesional = ICommandRegProfesional;
            _IQueryGetProfesional = iQueryGetProfesional;
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        [HttpPost]
        public string RegistrarProfesional([FromBody] Profesional profesional)
        {
            return _ICommandRegProfesional.RegistrarProfesional(profesional);

        }

        [HttpGet("{id}")]
        public IActionResult GetRegistroProfesional(string id)
        {
            return Ok(_IQueryGetProfesional.ObtenerProfesional(id));
        }


    }
}


