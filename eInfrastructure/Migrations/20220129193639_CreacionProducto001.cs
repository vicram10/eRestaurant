using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class CreacionProducto001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$cj7GAUkP8V9hgkPv7z8G6.1c4DMrX8eeTH8JaSYHnfZv.G/ZjKvzO", new DateTime(2022, 1, 29, 16, 36, 38, 738, DateTimeKind.Local).AddTicks(9700) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$8/PkXNoq6m5WStzQGAKnPeX6chh7B1lWDfY3QzEmPf/01HUqZMjke", new DateTime(2022, 1, 29, 12, 11, 27, 620, DateTimeKind.Local).AddTicks(1503) });
        }
    }
}
