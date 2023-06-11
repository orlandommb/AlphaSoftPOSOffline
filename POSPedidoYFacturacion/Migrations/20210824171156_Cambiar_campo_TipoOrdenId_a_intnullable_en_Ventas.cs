using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Cambiar_campo_TipoOrdenId_a_intnullable_en_Ventas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_TipoOrdenes_TipoOrdenId",
                table: "Ventas");

            migrationBuilder.AlterColumn<int>(
                name: "TipoOrdenId",
                table: "Ventas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_TipoOrdenes_TipoOrdenId",
                table: "Ventas",
                column: "TipoOrdenId",
                principalTable: "TipoOrdenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_TipoOrdenes_TipoOrdenId",
                table: "Ventas");

            migrationBuilder.AlterColumn<int>(
                name: "TipoOrdenId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_TipoOrdenes_TipoOrdenId",
                table: "Ventas",
                column: "TipoOrdenId",
                principalTable: "TipoOrdenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
