using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendBiblioteca.Migrations
{
    public partial class ChangeAllows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "autorizacion",
                table: "Detalle_Usuario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "activo",
                table: "Detalle_Usuario",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "autorizacion",
                table: "Detalle_Usuario",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "activo",
                table: "Detalle_Usuario",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
