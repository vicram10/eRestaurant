using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class CarritoFechaPago01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPago",
                table: "Carrito",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$VVjEd4utxUieu9.wPQzpGe/8AhQi2fBh6rChzMQONPj5VyiGFxI3G", new DateTime(2022, 2, 4, 21, 34, 46, 255, DateTimeKind.Local).AddTicks(3822) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaPago",
                table: "Carrito");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$Gdoe/PxT6smTyAoThD0rDOwm6NWRm0Cx4kkCDu7Tbyg4JsVe1xsYS", new DateTime(2022, 2, 2, 20, 26, 58, 110, DateTimeKind.Local).AddTicks(5252) });
        }
    }
}
