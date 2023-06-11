using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_Campo_Codigo_a_Producto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Productos");
        }
    }
}
