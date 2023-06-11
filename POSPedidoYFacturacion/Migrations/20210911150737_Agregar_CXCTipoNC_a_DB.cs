using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaSoftPOSOffline.Migrations
{
    public partial class Agregar_CXCTipoNC_a_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CXCTipoNC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CreaNCF = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXCTipoNC", x => x.Id);
                });

            migrationBuilder.Sql(@"
                IF not exists (select * From CXCTipoNC Where Nombre = 'Normal')
                BEGIN
                INSERT INTO CXCTipoNC  (Nombre, CreaNCF) values ('Normal', 0);
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CXCTipoNC");
        }
    }
}
