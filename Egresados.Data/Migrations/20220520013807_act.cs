using Microsoft.EntityFrameworkCore.Migrations;

namespace Egresados.Data.Migrations
{
    public partial class act : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
