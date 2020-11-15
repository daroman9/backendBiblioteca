using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendBiblioteca.Migrations
{
    public partial class ChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tipoMaterial",
                table: "Tipo_Material",
                newName: "nombre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Tipo_Material",
                newName: "tipoMaterial");
        }
    }
}
