using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_Impuestos_y_ImpuestoTipos_junto_a_Productos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImpuestoId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImpuestoTipoId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ImpuestoId",
                table: "Productos",
                column: "ImpuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ImpuestoTipoId",
                table: "Productos",
                column: "ImpuestoTipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Impuestos_ImpuestoId",
                table: "Productos",
                column: "ImpuestoId",
                principalTable: "Impuestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_ImpuestoTipos_ImpuestoTipoId",
                table: "Productos",
                column: "ImpuestoTipoId",
                principalTable: "ImpuestoTipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Impuestos_ImpuestoId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_ImpuestoTipos_ImpuestoTipoId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ImpuestoId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ImpuestoTipoId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ImpuestoId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ImpuestoTipoId",
                table: "Productos");
        }
    }
}
