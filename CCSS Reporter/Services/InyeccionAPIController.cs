using CCSS_Reporter.DB;
using CCSS_Reporter.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CCSS_Reporter.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class InyeccionAPIController : ControllerBase
    {
        private readonly ICommandRegInyeccion _ICommandRegInyeccion;

        public InyeccionAPIController(ICommandRegInyeccion ICommandRegInyeccion)
        {
            _ICommandRegInyeccion = ICommandRegInyeccion;
        }
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        [HttpPost]
        public IActionResult RegistrarInyeccion([FromBody] Inyeccion inyeccion)
        {
            _ICommandRegInyeccion.RegistrarInyeccion(inyeccion);
            return CreatedAtAction("", "");
        }

        [HttpGet("{id}")]
        public IActionResult GetRegistroInyecciones(string id)
        {
            return Ok("_IQueryGetClinica.ObtenerClinica(id)");
        }


    }
}
