using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendBiblioteca.Migrations
{
    public partial class ChangeNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nombreEditorial",
                table: "Editorial",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "nombreDispositivo",
                table: "Dispositivos",
                newName: "nombre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Editorial",
                newName: "nombreEditorial");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Dispositivos",
                newName: "nombreDispositivo");
        }
    }
}
