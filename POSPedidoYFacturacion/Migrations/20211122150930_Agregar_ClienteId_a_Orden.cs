using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_ClienteId_a_Orden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Ordenes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ClienteId",
                table: "Ordenes",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_ClienteId",
                table: "Ordenes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_ClienteId",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_ClienteId",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Ordenes");
        }
    }
}
