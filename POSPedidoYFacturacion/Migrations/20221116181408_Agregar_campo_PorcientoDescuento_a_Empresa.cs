using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_campo_PorcientoDescuento_a_Empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MontoManoObra",
                table: "Ventas",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcientoDescuento",
                table: "Empresa",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoManoObra",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "PorcientoDescuento",
                table: "Empresa");
        }
    }
}
