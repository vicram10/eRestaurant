using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class Inicio01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    IdEstado = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescripcionEstado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.IdEstado);
                });

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
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cedula = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Contraseña = table.Column<string>(nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    IdUsuarioRegistro = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    IdiomaElegido = table.Column<string>(maxLength: 3, nullable: false),
                    esAdministrador = table.Column<bool>(nullable: false),
                    IdEstado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Estados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaProducto",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescripcionCategoria = table.Column<string>(nullable: true),
                    IdUsuarioRegistro = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProducto", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "FK_CategoriaProducto_Usuarios_IdUsuarioRegistro",
                        column: x => x.IdUsuarioRegistro,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreProducto = table.Column<string>(nullable: true),
                    DescripcionProducto = table.Column<string>(nullable: true),
                    ImagenProducto = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false),
                    IdCategoria = table.Column<int>(nullable: false),
                    IdEstadoProducto = table.Column<int>(nullable: false),
                    IdUsuarioRegistro = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_CategoriaProducto_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "CategoriaProducto",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_EstadosProductos_IdEstadoProducto",
                        column: x => x.IdEstadoProducto,
                        principalTable: "EstadosProductos",
                        principalColumn: "IdEstadoProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Usuarios_IdUsuarioRegistro",
                        column: x => x.IdUsuarioRegistro,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    IdCarrito = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProducto = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    UrlPago = table.Column<string>(nullable: true),
                    DocIDAdamsPay = table.Column<string>(nullable: true),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
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
                        name: "FK_Carrito_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "IdEstado", "DescripcionEstado" },
                values: new object[,]
                {
                    { 1, "USUARIO ACTIVO" },
                    { 2, "USUARIO BLOQUEADO" },
                    { 99, "USUARIO BORRADO" }
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

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Cedula", "Contraseña", "Correo", "FechaRegistro", "IdEstado", "IdUsuarioRegistro", "IdiomaElegido", "Nombre", "esAdministrador" },
                values: new object[] { 1, "ADM001", "$2a$11$4sefB4KWR/G7dNvkI4Kpn.LNqWqvEckyOJvodaE6hLeKj3GPHSmwy", "vicram10@gmail.com", new DateTime(2022, 2, 2, 19, 52, 27, 545, DateTimeKind.Local).AddTicks(2622), 1, 1, "ES", "ADMINISTRADOR GENERAL", true });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_IdProducto",
                table: "Carrito",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_IdUsuario",
                table: "Carrito",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaProducto_IdUsuarioRegistro",
                table: "CategoriaProducto",
                column: "IdUsuarioRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdEstadoProducto",
                table: "Productos",
                column: "IdEstadoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdUsuarioRegistro",
                table: "Productos",
                column: "IdUsuarioRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Cedula",
                table: "Usuarios",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Correo",
                table: "Usuarios",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdEstado",
                table: "Usuarios",
                column: "IdEstado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "CategoriaProducto");

            migrationBuilder.DropTable(
                name: "EstadosProductos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
