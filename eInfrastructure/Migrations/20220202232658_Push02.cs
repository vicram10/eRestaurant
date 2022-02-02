using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class Push02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdNotificacion = table.Column<string>(nullable: true),
                    TipoNotificacion = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    FechaNotificacion = table.Column<DateTime>(nullable: false),
                    IdComercio = table.Column<string>(nullable: true),
                    IdAplicacion = table.Column<string>(nullable: true),
                    Ambiente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$Gdoe/PxT6smTyAoThD0rDOwm6NWRm0Cx4kkCDu7Tbyg4JsVe1xsYS", new DateTime(2022, 2, 2, 20, 26, 58, 110, DateTimeKind.Local).AddTicks(5252) });

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_IdNotificacion",
                table: "Notificaciones",
                column: "IdNotificacion",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$4sefB4KWR/G7dNvkI4Kpn.LNqWqvEckyOJvodaE6hLeKj3GPHSmwy", new DateTime(2022, 2, 2, 19, 52, 27, 545, DateTimeKind.Local).AddTicks(2622) });
        }
    }
}
