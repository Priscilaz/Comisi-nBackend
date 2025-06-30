using FastCommissionBack.Data;
using FastCommissionBack.Repositories;

namespace FastCommissionBack.Services
{
    public class ComisionDto
    {
        public string Vendedor { get; set; }
        public decimal Comision { get; set; }
    }

    public class ComisionService
    {
        private readonly IVentaRepository _repo;

        public ComisionService(IVentaRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<object> ObtenerVentasDto()
        {
            return _repo
                .GetVentasEnRango(DateTime.MinValue, DateTime.MaxValue)
                .Select(v => new {
                    Fecha = v.Fecha,
                    Vendedor = v.Vendedor.Nombre,
                    Monto = v.Valor
                })
                .ToList();
        }

        public IEnumerable<object> ObtenerReglasDto()
        {
            return _repo
                .GetReglas()
                .Select(r => new {
                    Porcentaje = r.Porcentaje,
                    Cantidad = r.Cantidad
                })
                .ToList();
        }

        public IEnumerable<ComisionDto> CalcularComisiones(DateTime inicio, DateTime fin)
        {
            var ventas = _repo.GetVentasEnRango(inicio, fin);
            var reglas = _repo.GetReglas();
            var vendedores = _repo.GetVendedores();

            return ventas
                .GroupBy(v => v.VendedorId)
                .Select(g =>
                {
                    var total = g.Sum(v =>
                    {
                        var regla = reglas.FirstOrDefault(r => r.Cantidad == v.Valor);
                        return regla != null
                            ? v.Valor * regla.Porcentaje
                            : 0m;
                    });

                    var nombre = vendedores.First(x => x.Id == g.Key).Nombre;
                    return new ComisionDto { Vendedor = nombre, Comision = total };
                });
        }
    }
}
