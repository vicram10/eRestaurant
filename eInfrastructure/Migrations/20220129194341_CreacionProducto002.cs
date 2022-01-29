using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class CreacionProducto002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosProductos",
                columns: table => new
                {
                    IdEstadoProducto = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescripcionProducto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosProductos", x => x.IdEstadoProducto);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescripcionProducto = table.Column<string>(nullable: true),
                    ImagenProducto = table.Column<string>(nullable: true),
                    IdEstadoProducto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_EstadosProductos_IdEstadoProducto",
                        column: x => x.IdEstadoProducto,
                        principalTable: "EstadosProductos",
                        principalColumn: "IdEstadoProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadosProductos",
                columns: new[] { "IdEstadoProducto", "DescripcionProducto" },
                values: new object[,]
                {
                    { 1, "ACTIVO" },
                    { 2, "INACTIVO" },
                    { 99, "BORRADO" }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$RIEg1wnt1jw/uAKtrPMmUem6JaY/h5mUDSGrhffMDhabDFVApNacy", new DateTime(2022, 1, 29, 16, 43, 40, 989, DateTimeKind.Local).AddTicks(7900) });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdEstadoProducto",
                table: "Productos",
                column: "IdEstadoProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "EstadosProductos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$cj7GAUkP8V9hgkPv7z8G6.1c4DMrX8eeTH8JaSYHnfZv.G/ZjKvzO", new DateTime(2022, 1, 29, 16, 36, 38, 738, DateTimeKind.Local).AddTicks(9700) });
        }
    }
}
