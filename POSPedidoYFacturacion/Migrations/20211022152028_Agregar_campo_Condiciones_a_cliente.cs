using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_campo_Condiciones_a_cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Condiciones",
                table: "Clientes",
                type: "int",
                maxLength: 3,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condiciones",
                table: "Clientes");
        }
    }
}
