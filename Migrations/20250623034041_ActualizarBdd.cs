using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastCommissionBack.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarBdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reglas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(5,4)", precision: 5, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reglas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendedorId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Vendedores_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Reglas",
                columns: new[] { "Id", "Cantidad", "Porcentaje" },
                values: new object[,]
                {
                    { 1, 600m, 0.06m },
                    { 2, 500m, 0.08m },
                    { 3, 800m, 0.10m },
                    { 4, 1000m, 1.15m }
                });

            migrationBuilder.InsertData(
                table: "Vendedores",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Pablo Perez" },
                    { 2, "Camila Benavides" },
                    { 3, "Ana Castro" },
                    { 4, "Johny Martinez" },
                    { 5, "Laura Torres" }
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "Id", "Fecha", "Valor", "VendedorId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 400m, 1 },
                    { 2, new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 600m, 2 },
                    { 3, new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m, 3 },
                    { 4, new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 300m, 4 },
                    { 5, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m, 5 },
                    { 6, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 800m, 1 },
                    { 7, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, 2 },
                    { 8, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 700m, 3 },
                    { 9, new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 900m, 4 },
                    { 10, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200m, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_VendedorId",
                table: "Ventas",
                column: "VendedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reglas");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Vendedores");
        }
    }
}
