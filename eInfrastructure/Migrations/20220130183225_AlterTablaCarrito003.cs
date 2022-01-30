using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class AlterTablaCarrito003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocIDAdamsPay",
                table: "Carrito",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlPago",
                table: "Carrito",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$.z8IYJ.lr58BjSz4RiqyheVbKGgxAWHYbpP7n0HlNYNJeEiKsy5n.", new DateTime(2022, 1, 30, 15, 32, 25, 85, DateTimeKind.Local).AddTicks(8747) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocIDAdamsPay",
                table: "Carrito");

            migrationBuilder.DropColumn(
                name: "UrlPago",
                table: "Carrito");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$IUH5kqOQufE7MkXhbMFON.tLbs4LRVFOhan0qvP9fVpTR/k0zqUii", new DateTime(2022, 1, 30, 12, 10, 42, 270, DateTimeKind.Local).AddTicks(3210) });
        }
    }
}
