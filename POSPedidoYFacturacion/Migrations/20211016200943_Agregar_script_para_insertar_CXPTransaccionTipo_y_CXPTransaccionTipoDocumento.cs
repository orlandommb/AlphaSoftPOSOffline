using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_script_para_insertar_CXPTransaccionTipo_y_CXPTransaccionTipoDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            
            IF not exists (select * From CXPTransaccionTipos Where Nombre = 'Nota de Credito')
            BEGIN
                declare @IdTipoTranNC INT
                INSERT INTO CXPTransaccionTipos (Nombre) values ('Nota de Credito');
                            
                set @IdTipoTranNC = (select Id From CXPTransaccionTipos Where Nombre = 'Nota de Credito')

                IF not exists (select * From CXPTransaccionTipoDocumentos Where Nombre = 'NC Normal' and CXPTransaccionTipoId = @IdTipoTranNC)
                BEGIN     
                INSERT INTO CXPTransaccionTipoDocumentos (CXPTransaccionTipoId ,Nombre) values (@IdTipoTranNC, 'NC Normal');
                END
            END
                            
            IF not exists (select * From CXPTransaccionTipos Where Nombre = 'Nota de Debito')
            BEGIN
                declare @IdTipoTranND INT
                INSERT INTO CXPTransaccionTipos (Nombre) values ('Nota de Debito');

                set @IdTipoTranND = (select Id From CXPTransaccionTipos Where Nombre = 'Nota de Debito')
                
                IF not exists (select * From CXPTransaccionTipoDocumentos Where Nombre = 'ND Normal' and CXPTransaccionTipoId = @IdTipoTranND)
                BEGIN
                INSERT INTO CXPTransaccionTipoDocumentos (CXPTransaccionTipoId, Nombre) values (@IdTipoTranND ,'ND Normal');
                END
            END
                            
            IF not exists (select * From CXPTransaccionTipos Where Nombre = 'Registro de Pago')
            BEGIN
                declare @IdTipoTranRP INT
                INSERT INTO CXPTransaccionTipos (Nombre) values ('Registro de Pago');
                    
                set @IdTipoTranRP = (select Id From CXPTransaccionTipos Where Nombre = 'Registro de Pago')

                IF not exists (select * From CXPTransaccionTipoDocumentos Where Nombre = 'RI Normal' and CXPTransaccionTipoId = @IdTipoTranRP)
                BEGIN
                INSERT INTO CXPTransaccionTipoDocumentos (CXPTransaccionTipoId ,Nombre) values (@IdTipoTranRP,'RP Normal');
                END
            END 

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
