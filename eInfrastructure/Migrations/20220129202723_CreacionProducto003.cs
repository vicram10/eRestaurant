using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInfrastructure.Migrations
{
    public partial class CreacionProducto003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$IMrkJDdihaoSKavK84ruluaH14jyU3pwxSVo70zZQC5C7I6PdnLwu", new DateTime(2022, 1, 29, 17, 27, 23, 183, DateTimeKind.Local).AddTicks(2414) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaRegistro" },
                values: new object[] { "$2a$11$RIEg1wnt1jw/uAKtrPMmUem6JaY/h5mUDSGrhffMDhabDFVApNacy", new DateTime(2022, 1, 29, 16, 43, 40, 989, DateTimeKind.Local).AddTicks(7900) });
        }
    }
}
