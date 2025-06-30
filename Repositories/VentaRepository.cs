using FastCommissionBack.Data;
using FastCommissionBack.Models;
using Microsoft.EntityFrameworkCore;

namespace FastCommissionBack.Repositories
{
    public interface IVentaRepository
    {
        List<Venta> GetVentasEnRango(DateTime inicio, DateTime fin);
        List<Regla> GetReglas();
        List<Vendedor> GetVendedores();
    }
    public class VentaRepository : IVentaRepository
    {
        private readonly AppDbContext _ctx;
        public VentaRepository(AppDbContext ctx) => _ctx = ctx;

        public List<Venta> GetVentasEnRango(DateTime inicio, DateTime fin) =>
            _ctx.Ventas
                .Where(v => v.Fecha >= inicio && v.Fecha <= fin)
                .Include(v => v.Vendedor)
                .ToList();

        public List<Regla> GetReglas() =>
            _ctx.Reglas.ToList();

        public List<Vendedor> GetVendedores() =>
            _ctx.Vendedores.ToList();
    }
}
