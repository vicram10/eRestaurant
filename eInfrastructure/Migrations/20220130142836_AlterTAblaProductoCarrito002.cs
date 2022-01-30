using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class AlterTAblaProductoCarrito002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    IdCarrito = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProducto = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    UsuarioSolicitoIdUsuario = table.Column<int>(nullable: true),
                    FechaRegistros = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.IdCarrito);
                    table.ForeignKey(
                        name: "FK_Carrito_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carrito_Usuarios_UsuarioSolicitoIdUsuario",
                        column: x => x.UsuarioSolicitoIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$GzAjFZyEX.JcmJR7SKj/z.T2AR0WOXuaRbLhVIVK2PxCSXsU/qe/.", new DateTime(2022, 1, 30, 11, 28, 36, 714, DateTimeKind.Local).AddTicks(8668) });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_IdProducto",
                table: "Carrito",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_UsuarioSolicitoIdUsuario",
                table: "Carrito",
                column: "UsuarioSolicitoIdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$9P8Aqqh6r3ZZGs.0dbY8l.yZSjSejXwfezK.BgnGAoYW6sOjoBhQi", new DateTime(2022, 1, 30, 11, 26, 7, 790, DateTimeKind.Local).AddTicks(4960) });
        }
    }
}
