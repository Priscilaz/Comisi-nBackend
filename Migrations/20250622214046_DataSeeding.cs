using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastCommissionBack.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Porcentaje",
                table: "Reglas",
                type: "decimal(5,4)",
                precision: 5,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reglas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reglas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reglas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reglas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Vendedores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vendedores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vendedores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vendedores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vendedores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "Porcentaje",
                table: "Reglas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,4)",
                oldPrecision: 5,
                oldScale: 4);
        }
    }
}
