using FastCommissionBack.Data;

namespace FastCommissionBack.Services
{
    public class ComisionDto
    {
        public string Vendedor { get; set; }
        public decimal Comision { get; set; }
    }

    public class ComisionService
    {
        private readonly AppDbContext _ctx;

        public ComisionService(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ComisionDto> CalcularComisiones(DateTime inicio, DateTime fin)
        {
            // 1) Traer ventas en el rango
            var ventas = _ctx.Ventas
                .Where(v => v.Fecha >= inicio && v.Fecha <= fin)
                .ToList();

            // 2) Traer reglas y vendedores a memoria
            var reglas = _ctx.Reglas.ToList();
            var vendedores = _ctx.Vendedores.ToList();

            // 3) Agrupar por vendedor y aplicar regla exacta
            var resultado = ventas
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

            return resultado;
        }
    }
}
