using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_Script_para_insertar_CXCTransaccionTipoDocumento_devolucio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            
            IF not exists (select * From CXCTransaccionTipoDocumentos Where Nombre = 'NC Devolucion' and CXCTransaccionTipoId = 1)
                BEGIN     
                INSERT INTO CXCTransaccionTipoDocumentos (CXCTransaccionTipoId ,Nombre) values (1, 'NC Devolucion');
                END
            
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
