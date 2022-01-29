using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class AlterProducto002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$S7jKJEhPCxZb66jBYdoGMewYAEKBBnk6Uwm3zacKsBYDLRgt3b9ju", new DateTime(2022, 1, 29, 17, 37, 26, 876, DateTimeKind.Local).AddTicks(7041) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$9V2Gta9diId1BvYf8OV20OINvKoXyBPuRzpjoqwkdL8OY4GDrU.Ga", new DateTime(2022, 1, 29, 17, 34, 38, 430, DateTimeKind.Local).AddTicks(9825) });
        }
    }
}
