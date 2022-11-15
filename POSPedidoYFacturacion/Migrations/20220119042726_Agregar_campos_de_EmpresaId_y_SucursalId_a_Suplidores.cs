using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_campos_de_EmpresaId_y_SucursalId_a_Suplidores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Suplidores",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "Suplidores",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Suplidores_EmpresaId",
                table: "Suplidores",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Suplidores_SucursalId",
                table: "Suplidores",
                column: "SucursalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suplidores_Empresa_EmpresaId",
                table: "Suplidores",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suplidores_Sucursales_SucursalId",
                table: "Suplidores",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suplidores_Empresa_EmpresaId",
                table: "Suplidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Suplidores_Sucursales_SucursalId",
                table: "Suplidores");

            migrationBuilder.DropIndex(
                name: "IX_Suplidores_EmpresaId",
                table: "Suplidores");

            migrationBuilder.DropIndex(
                name: "IX_Suplidores_SucursalId",
                table: "Suplidores");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Suplidores");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Suplidores");
        }
    }
}
