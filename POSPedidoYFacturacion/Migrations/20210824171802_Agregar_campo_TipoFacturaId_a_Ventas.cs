using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_campo_TipoFacturaId_a_Ventas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoFacturaId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_TipoFacturaId",
                table: "Ventas",
                column: "TipoFacturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_TipoFacturas_TipoFacturaId",
                table: "Ventas",
                column: "TipoFacturaId",
                principalTable: "TipoFacturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_TipoFacturas_TipoFacturaId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_TipoFacturaId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "TipoFacturaId",
                table: "Ventas");
        }
    }
}
