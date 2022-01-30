using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class AlterProducto005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Productos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioRegistro",
                table: "Productos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "CategoriaProducto",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioRegistro",
                table: "CategoriaProducto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$AxnlY/yU81nd1ID6m0LzVeBH2oi0NDFp4NzjBVC8/50UdwIA66Amu", new DateTime(2022, 1, 30, 0, 12, 6, 801, DateTimeKind.Local).AddTicks(2425) });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdUsuarioRegistro",
                table: "Productos",
                column: "IdUsuarioRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaProducto_IdUsuarioRegistro",
                table: "CategoriaProducto",
                column: "IdUsuarioRegistro");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaProducto_Usuarios_IdUsuarioRegistro",
                table: "CategoriaProducto",
                column: "IdUsuarioRegistro",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Usuarios_IdUsuarioRegistro",
                table: "Productos",
                column: "IdUsuarioRegistro",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaProducto_Usuarios_IdUsuarioRegistro",
                table: "CategoriaProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Usuarios_IdUsuarioRegistro",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdUsuarioRegistro",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_CategoriaProducto_IdUsuarioRegistro",
                table: "CategoriaProducto");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdUsuarioRegistro",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "CategoriaProducto");

            migrationBuilder.DropColumn(
                name: "IdUsuarioRegistro",
                table: "CategoriaProducto");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$e3YROmjwejs/ej8.RIBnzep1Muy3dCqECP9TOUjlVqtFLBVl7Qjvq", new DateTime(2022, 1, 29, 22, 34, 7, 594, DateTimeKind.Local).AddTicks(4441) });
        }
    }
}
