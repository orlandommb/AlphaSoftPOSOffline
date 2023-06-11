
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Insertar_Info_Del_Sistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenDetalles_Ordenes_OrdenId",
                table: "OrdenDetalles");

            migrationBuilder.AlterColumn<int>(
                name: "OrdenId",
                table: "OrdenDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenDetalles_Ordenes_OrdenId",
                table: "OrdenDetalles",
                column: "OrdenId",
                principalTable: "Ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenDetalles_Ordenes_OrdenId",
                table: "OrdenDetalles");

            migrationBuilder.AlterColumn<int>(
                name: "OrdenId",
                table: "OrdenDetalles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenDetalles_Ordenes_OrdenId",
                table: "OrdenDetalles",
                column: "OrdenId",
                principalTable: "Ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
