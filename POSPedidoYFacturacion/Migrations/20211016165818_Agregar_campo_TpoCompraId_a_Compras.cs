using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_campo_TpoCompraId_a_Compras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoCompraId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_TipoCompraId",
                table: "Compras",
                column: "TipoCompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_TipoCompras_TipoCompraId",
                table: "Compras",
                column: "TipoCompraId",
                principalTable: "TipoCompras",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_TipoCompras_TipoCompraId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_TipoCompraId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "TipoCompraId",
                table: "Compras");
        }
    }
}
