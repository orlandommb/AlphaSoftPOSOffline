using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_Campo_ImprimirLogoEnOrden_y_ImprimirLogoEnFactura_A_Empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ImprimirLogoEnFactura",
                table: "Empresa",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ImprimirLogoEnOrden",
                table: "Empresa",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImprimirLogoEnFactura",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "ImprimirLogoEnOrden",
                table: "Empresa");
        }
    }
}
