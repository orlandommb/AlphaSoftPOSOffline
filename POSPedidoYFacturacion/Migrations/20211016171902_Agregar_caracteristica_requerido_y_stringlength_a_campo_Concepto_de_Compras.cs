using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_caracteristica_requerido_y_stringlength_a_campo_Concepto_de_Compras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Concepto",
                table: "Compras",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Compra de Mercancia",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Concepto",
                table: "Compras",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
