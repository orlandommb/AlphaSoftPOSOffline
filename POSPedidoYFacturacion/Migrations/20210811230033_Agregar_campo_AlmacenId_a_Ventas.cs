using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_campo_AlmacenId_a_Ventas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlmacenId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_AlmacenId",
                table: "Ventas",
                column: "AlmacenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Almacenes_AlmacenId",
                table: "Ventas",
                column: "AlmacenId",
                principalTable: "Almacenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Almacenes_AlmacenId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_AlmacenId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "AlmacenId",
                table: "Ventas");
        }
    }
}
