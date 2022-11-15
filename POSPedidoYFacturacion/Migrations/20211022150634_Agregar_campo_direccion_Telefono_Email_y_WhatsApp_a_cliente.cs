using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_campo_direccion_Telefono_Email_y_WhatsApp_a_cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CXCTransaccionDetalles_CXPTransacciones_CXPTransaccionId",
                table: "CXCTransaccionDetalles");

            migrationBuilder.DropIndex(
                name: "IX_CXCTransaccionDetalles_CXPTransaccionId",
                table: "CXCTransaccionDetalles");

            migrationBuilder.DropColumn(
                name: "CXPTransaccionId",
                table: "CXCTransaccionDetalles");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Clientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WhatsApp",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "WhatsApp",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "CXPTransaccionId",
                table: "CXCTransaccionDetalles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CXCTransaccionDetalles_CXPTransaccionId",
                table: "CXCTransaccionDetalles",
                column: "CXPTransaccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CXCTransaccionDetalles_CXPTransacciones_CXPTransaccionId",
                table: "CXCTransaccionDetalles",
                column: "CXPTransaccionId",
                principalTable: "CXPTransacciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
