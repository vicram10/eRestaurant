using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class Inicial : Migration
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

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "IdEstado", "DescripcionEstado" },
                values: new object[] { 1, "USUARIO ACTIVO" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "IdEstado", "DescripcionEstado" },
                values: new object[] { 2, "USUARIO BLOQUEADO" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "IdEstado", "DescripcionEstado" },
                values: new object[] { 99, "USUARIO BORRADO" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Cedula", "Contraseña", "Correo", "FechaRegistro", "IdEstado", "IdUsuarioRegistro", "IdiomaElegido", "Nombre", "esAdministrador" },
                values: new object[] { 1, "ADM001", "$2a$11$8/PkXNoq6m5WStzQGAKnPeX6chh7B1lWDfY3QzEmPf/01HUqZMjke", "vicram10@gmail.com", new DateTime(2022, 1, 29, 12, 11, 27, 620, DateTimeKind.Local).AddTicks(1503), 1, 1, "ES", "ADMINISTRADOR GENERAL", true });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdEstado",
                table: "Usuarios",
                column: "IdEstado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
