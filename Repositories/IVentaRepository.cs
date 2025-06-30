using FastCommissionBack.Models;

namespace FastCommissionBack.Repositories
{
    public interface IVentaRepository
    {
        List<Venta> GetVentasEnRango(DateTime inicio, DateTime fin);
        List<Regla> GetReglas();
        List<Vendedor> GetVendedores();
    }
}
