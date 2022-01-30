using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class AlterTablaCarrito001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRegistros",
                table: "Carrito");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Carrito",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$IUH5kqOQufE7MkXhbMFON.tLbs4LRVFOhan0qvP9fVpTR/k0zqUii", new DateTime(2022, 1, 30, 12, 10, 42, 270, DateTimeKind.Local).AddTicks(3210) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Carrito");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistros",
                table: "Carrito",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$oL3cY813TpHCj2IW5yrNo.DNRshXhiFmktVOrktQJC0mdqqr6aY0e", new DateTime(2022, 1, 30, 12, 9, 55, 481, DateTimeKind.Local).AddTicks(7277) });
        }
    }
}
