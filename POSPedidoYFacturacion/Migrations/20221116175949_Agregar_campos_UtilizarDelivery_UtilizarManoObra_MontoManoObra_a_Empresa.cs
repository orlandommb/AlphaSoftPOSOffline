using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_campos_UtilizarDelivery_UtilizarManoObra_MontoManoObra_a_Empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MontoManoObra",
                table: "Empresa",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "UtilizarDelivery",
                table: "Empresa",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UtilizarManoDeObra",
                table: "Empresa",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoManoObra",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "UtilizarDelivery",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "UtilizarManoDeObra",
                table: "Empresa");
        }
    }
}
