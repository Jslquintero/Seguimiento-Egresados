using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Egresados.Data.Migrations
{
    public partial class in2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CentroEducativo",
                columns: new[] { "Id", "Codigo", "FacultadId", "FechaAlta", "FechaModificacion", "Nombre" },
                values: new object[] { 1, "CRA", 1, new DateTime(2022, 5, 24, 21, 10, 11, 751, DateTimeKind.Local).AddTicks(3294), null, "Centro Regional de Azuero" });

            migrationBuilder.InsertData(
                table: "Facultad",
                columns: new[] { "Id", "CentroEducativoId", "CentroId", "Codigo", "EventoId", "FechaAlta", "FechaModificacion", "Nombre" },
                values: new object[] { 1, null, null, "FISC", null, new DateTime(2022, 5, 24, 21, 10, 11, 751, DateTimeKind.Local).AddTicks(2349), null, "Sistemas" });

            migrationBuilder.InsertData(
                table: "LugarEvento",
                columns: new[] { "Id", "Codigo", "EventoId", "FechaAlta", "FechaModificacion", "Nombre" },
                values: new object[] { 1, "HTAzuero", null, new DateTime(2022, 5, 24, 21, 10, 11, 751, DateTimeKind.Local).AddTicks(491), null, "Hotel Azuero" });

            migrationBuilder.InsertData(
                table: "Provincia",
                columns: new[] { "Id", "Codigo", "FechaAlta", "FechaModificacion", "Nombre" },
                values: new object[,]
                {
                    { 1, "06", new DateTime(2022, 5, 24, 21, 10, 11, 749, DateTimeKind.Local).AddTicks(501), null, "Herrera" },
                    { 2, "07", new DateTime(2022, 5, 24, 21, 10, 11, 749, DateTimeKind.Local).AddTicks(9553), null, "Los Santos" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CentroEducativo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Facultad",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LugarEvento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provincia",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provincia",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
