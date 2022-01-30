using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class AlterProducto004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreProducto",
                table: "Productos",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$e3YROmjwejs/ej8.RIBnzep1Muy3dCqECP9TOUjlVqtFLBVl7Qjvq", new DateTime(2022, 1, 29, 22, 34, 7, 594, DateTimeKind.Local).AddTicks(4441) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreProducto",
                table: "Productos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$S7jKJEhPCxZb66jBYdoGMewYAEKBBnk6Uwm3zacKsBYDLRgt3b9ju", new DateTime(2022, 1, 29, 17, 37, 26, 876, DateTimeKind.Local).AddTicks(7041) });
        }
    }
}
