using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class AlterTAblaProductoCarrito001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Productos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$9P8Aqqh6r3ZZGs.0dbY8l.yZSjSejXwfezK.BgnGAoYW6sOjoBhQi", new DateTime(2022, 1, 30, 11, 26, 7, 790, DateTimeKind.Local).AddTicks(4960) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Productos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$AxnlY/yU81nd1ID6m0LzVeBH2oi0NDFp4NzjBVC8/50UdwIA66Amu", new DateTime(2022, 1, 30, 0, 12, 6, 801, DateTimeKind.Local).AddTicks(2425) });
        }
    }
}
