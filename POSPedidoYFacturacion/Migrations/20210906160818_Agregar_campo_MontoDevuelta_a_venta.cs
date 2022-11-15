using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_campo_MontoDevuelta_a_venta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MontoDevuelta",
                table: "Ventas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoDevuelta",
                table: "Ventas");
        }
    }
}
