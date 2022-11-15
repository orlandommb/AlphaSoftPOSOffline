using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Insertar_TipoFacturas_a_BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

IF not exists (select * From TipoFacturas Where Nombre = 'Credito' )
BEGIN
INSERT INTO TipoFacturas  (Nombre) values ('Credito')
END 

IF not exists (select * From TipoFacturas Where Nombre = 'Contado' )
BEGIN
INSERT INTO TipoFacturas  (Nombre) values ('Contado')
END 
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
