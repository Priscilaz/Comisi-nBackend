using FastCommissionBack.Models;

namespace FastCommissionBack.Services
{
    public class ExactMatchStrategy : IComisionStrategy
    {
        public decimal CalcularComision(decimal valorVenta, IEnumerable<Regla> reglas)
        {
            // Busca regla cuya Cantidad == valorVenta
            var regla = reglas.FirstOrDefault(r => r.Cantidad == valorVenta);
            return regla is not null
                ? valorVenta * regla.Porcentaje
                : 0m;
        }
    }
}
