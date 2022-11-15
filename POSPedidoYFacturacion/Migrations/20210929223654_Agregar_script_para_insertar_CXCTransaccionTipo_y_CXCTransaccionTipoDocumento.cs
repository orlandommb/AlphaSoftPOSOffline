using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPedidoYFacturacion.Migrations
{
    public partial class Agregar_script_para_insertar_CXCTransaccionTipo_y_CXCTransaccionTipoDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            
            IF not exists (select * From CXCTransaccionTipos Where Nombre = 'Nota de Credito')
            BEGIN
                declare @IdTipoTranNC INT
                INSERT INTO CXCTransaccionTipos (Nombre) values ('Nota de Credito');
                            
                set @IdTipoTranNC = (select Id From CXCTransaccionTipos Where Nombre = 'Nota de Credito')

                IF not exists (select * From CXCTransaccionTipoDocumentos Where Nombre = 'NC Normal' and CXCTransaccionTipoId = @IdTipoTranNC)
                BEGIN     
                INSERT INTO CXCTransaccionTipoDocumentos (CXCTransaccionTipoId ,Nombre) values (@IdTipoTranNC, 'NC Normal');
                END
            END
                            
            IF not exists (select * From CXCTransaccionTipos Where Nombre = 'Nota de Debito')
            BEGIN
            declare @IdTipoTranND INT
                INSERT INTO CXCTransaccionTipos (Nombre) values ('Nota de Debito');

                set @IdTipoTranND = (select Id From CXCTransaccionTipos Where Nombre = 'Nota de Debito')
                
                IF not exists (select * From CXCTransaccionTipoDocumentos Where Nombre = 'ND Normal' and CXCTransaccionTipoId = @IdTipoTranND)
                BEGIN
                INSERT INTO CXCTransaccionTipoDocumentos (CXCTransaccionTipoId, Nombre) values (@IdTipoTranND ,'ND Normal');
                END
            END
                            
            IF not exists (select * From CXCTransaccionTipos Where Nombre = 'Recibo de Ingreso')
                BEGIN
                declare @IdTipoTranRI INT
                INSERT INTO CXCTransaccionTipos (Nombre) values ('Recibo de Ingreso');
                    
                set @IdTipoTranRI = (select Id From CXCTransaccionTipos Where Nombre = 'Recibo de Ingreso')

                IF not exists (select * From CXCTransaccionTipoDocumentos Where Nombre = 'RI Normal' and CXCTransaccionTipoId = @IdTipoTranRI)
                BEGIN
                INSERT INTO CXCTransaccionTipoDocumentos (CXCTransaccionTipoId ,Nombre) values (@IdTipoTranRI,'RI Normal');
                END
            END 

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
