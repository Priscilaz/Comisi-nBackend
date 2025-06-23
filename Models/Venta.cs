namespace FastCommissionBack.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int VendedorId { get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }

        public Vendedor Vendedor { get; set; }
    }
}
