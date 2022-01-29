using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class AlterProducto001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Productos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoriaProducto",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescripcionCategoria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProducto", x => x.IdCategoria);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$9V2Gta9diId1BvYf8OV20OINvKoXyBPuRzpjoqwkdL8OY4GDrU.Ga", new DateTime(2022, 1, 29, 17, 34, 38, 430, DateTimeKind.Local).AddTicks(9825) });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_CategoriaProducto_IdCategoria",
                table: "Productos",
                column: "IdCategoria",
                principalTable: "CategoriaProducto",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_CategoriaProducto_IdCategoria",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "CategoriaProducto");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Productos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$IMrkJDdihaoSKavK84ruluaH14jyU3pwxSVo70zZQC5C7I6PdnLwu", new DateTime(2022, 1, 29, 17, 27, 23, 183, DateTimeKind.Local).AddTicks(2414) });
        }
    }
}
