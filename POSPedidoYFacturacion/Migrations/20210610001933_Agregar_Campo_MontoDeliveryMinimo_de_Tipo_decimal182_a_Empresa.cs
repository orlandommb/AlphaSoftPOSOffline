using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_Campo_MontoDeliveryMinimo_de_Tipo_decimal182_a_Empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MontoMinimoDelivery",
                table: "Empresa",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoMinimoDelivery",
                table: "Empresa");
        }
    }
}
