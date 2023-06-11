using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_Campo_VistaDeProductosPorDefectoEnPuntoDeVenta_a_Empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VistaDeProductosPorDefectoEnPuntoDeVenta",
                table: "Empresa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VistaDeProductosPorDefectoEnPuntoDeVenta",
                table: "Empresa");
        }
    }
}
