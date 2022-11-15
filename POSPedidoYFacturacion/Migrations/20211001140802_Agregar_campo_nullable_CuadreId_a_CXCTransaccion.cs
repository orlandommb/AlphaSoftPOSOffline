using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_campo_nullable_CuadreId_a_CXCTransaccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuadreId",
                table: "CXCTransacciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CXCTransacciones_CuadreId",
                table: "CXCTransacciones",
                column: "CuadreId");

            migrationBuilder.AddForeignKey(
                name: "FK_CXCTransacciones_Cuadres_CuadreId",
                table: "CXCTransacciones",
                column: "CuadreId",
                principalTable: "Cuadres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CXCTransacciones_Cuadres_CuadreId",
                table: "CXCTransacciones");

            migrationBuilder.DropIndex(
                name: "IX_CXCTransacciones_CuadreId",
                table: "CXCTransacciones");

            migrationBuilder.DropColumn(
                name: "CuadreId",
                table: "CXCTransacciones");
        }
    }
}
