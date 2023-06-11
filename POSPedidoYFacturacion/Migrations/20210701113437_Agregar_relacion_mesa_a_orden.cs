using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_relacion_mesa_a_orden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MesaId",
                table: "Ordenes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_MesaId",
                table: "Ordenes",
                column: "MesaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Mesas_MesaId",
                table: "Ordenes",
                column: "MesaId",
                principalTable: "Mesas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Mesas_MesaId",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_MesaId",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "MesaId",
                table: "Ordenes");
        }
    }
}
