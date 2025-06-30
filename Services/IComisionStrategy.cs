using FastCommissionBack.Models;

namespace FastCommissionBack.Services
{
    public interface IComisionStrategy
    {
        
        /// Calcula la comisión de una venta dada la lista de reglas.
       
        decimal CalcularComision(decimal valorVenta, IEnumerable<Regla> reglas);
    }
}
