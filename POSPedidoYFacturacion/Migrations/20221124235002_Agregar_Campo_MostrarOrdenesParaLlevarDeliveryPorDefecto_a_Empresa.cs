using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_Campo_MostrarOrdenesParaLlevarDeliveryPorDefecto_a_Empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MostrarOrdenesParaLlevarDeliveryPorDefecto",
                table: "Empresa",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MostrarOrdenesParaLlevarDeliveryPorDefecto",
                table: "Empresa");
        }
    }
}
