using FastCommissionBack.Data;
using FastCommissionBack.Models;
using FastCommissionBack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastCommissionBack.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ComisionesController : ControllerBase
    {
        private readonly AppDbContext _ctx;
        private readonly ComisionService _svc;

        public ComisionesController(AppDbContext ctx, ComisionService svc)
        {
            _ctx = ctx;
            _svc = svc;
        }

        
        // GET api/comisiones/ventas
        [HttpGet("ventas")]
        public IActionResult GetVentas()
        {
            var ventas = _ctx.Ventas
                .Include(v => v.Vendedor)
                .Select(v => new {
                    Fecha = v.Fecha,
                    Vendedor = v.Vendedor.Nombre,
                    Monto = v.Valor
                })
                .ToList();

            return Ok(ventas);
        }
        
       
        // GET api/comisiones/reglas
        [HttpGet("reglas")]
        public IActionResult GetReglas()
        {
            var reglas = _ctx.Reglas
                .Select(r => new {
                    Porcentaje = r.Porcentaje,
                    Cantidad = r.Cantidad
                })
                .ToList();

            return Ok(reglas);
        }

        
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
