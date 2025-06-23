using FastCommissionBack.Models;
using Microsoft.EntityFrameworkCore;

namespace FastCommissionBack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Regla> Reglas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Regla>(e =>
            {
                e.Property(r => r.Cantidad)
                 .HasPrecision(18, 2);
                e.Property(r => r.Porcentaje)
                 .HasPrecision(5, 4);
            });
            modelBuilder.Entity<Venta>(e =>
                e.Property(v => v.Valor)
                 .HasPrecision(18, 2));


            //Seeding
            modelBuilder.Entity<Vendedor>().HasData(
                new Vendedor { Id = 1, Nombre = "Pablo Perez" },
                new Vendedor { Id = 2, Nombre = "Camila Benavides" },
                new Vendedor { Id = 3, Nombre = "Ana Castro" },
                new Vendedor { Id = 4, Nombre = "Johny Martinez" },
                new Vendedor { Id = 5, Nombre = "Laura Torres" }
            );

            modelBuilder.Entity<Regla>().HasData(
                new Regla { Id = 1, Cantidad = 600m, Porcentaje = 0.06m },
                new Regla { Id = 2, Cantidad = 500m, Porcentaje = 0.08m },
                new Regla { Id = 3, Cantidad = 800m, Porcentaje = 0.10m },
                new Regla { Id = 4, Cantidad = 1000m, Porcentaje = 1.15m }
            );

            modelBuilder.Entity<Venta>().HasData(
                new Venta { Id = 1, VendedorId = 1, Valor = 400m, Fecha = new DateTime(2025, 1, 21) },
                new Venta { Id = 2, VendedorId = 2, Valor = 600m, Fecha = new DateTime(2025, 2, 28) },
                new Venta { Id = 3, VendedorId = 3, Valor = 200m, Fecha = new DateTime(2025, 3, 3) },
                new Venta { Id = 4, VendedorId = 4, Valor = 300m, Fecha = new DateTime(2025, 6, 9) },
                new Venta { Id = 5, VendedorId = 5, Valor = 1000m, Fecha = new DateTime(2025, 6, 15) },
                new Venta { Id = 6, VendedorId = 1, Valor = 800m, Fecha = new DateTime(2025, 4, 20) },
                new Venta { Id = 7, VendedorId = 2, Valor = 500m, Fecha = new DateTime(2025, 5, 22) },
                new Venta { Id = 8, VendedorId = 3, Valor = 700m, Fecha = new DateTime(2025, 1, 25) },
                new Venta { Id = 9, VendedorId = 4, Valor = 900m, Fecha = new DateTime(2025, 2, 28) },
                new Venta { Id = 10, VendedorId = 5, Valor = 1200m, Fecha = new DateTime(2025, 6, 30) }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
