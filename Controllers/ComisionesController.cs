using FastCommissionBack.Models;
using FastCommissionBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastCommissionBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComisionesController : ControllerBase
    {
        private readonly ComisionService _svc;

        public ComisionesController(ComisionService svc)
        {
            _svc = svc;
        }

        // GET api/comisiones/ventas
        [HttpGet("ventas")]
        public IActionResult GetVentas() =>
            Ok(_svc.ObtenerVentasDto());

        // GET api/comisiones/reglas
        [HttpGet("reglas")]
        public IActionResult GetReglas() =>
            Ok(_svc.ObtenerReglasDto());

        // POST api/comisiones
        [HttpPost]
        public IActionResult Post([FromBody] ComisionRequest req)
        {
            if (req.Inicio > req.Fin)
                return BadRequest("La fecha de inicio debe ser ≤ fecha de fin.");

            var coms = _svc.CalcularComisiones(req.Inicio, req.Fin);
            return Ok(coms);
        }
    }
}
