using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendBiblioteca.Migrations
{
    public partial class DeleteIdUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Prestamos_AspNetUsers_id_Usuario",
                table: "Material_Prestamos");

            migrationBuilder.RenameColumn(
                name: "id_Usuario",
                table: "Material_Prestamos",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Material_Prestamos_id_Usuario",
                table: "Material_Prestamos",
                newName: "IX_Material_Prestamos_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Prestamos_AspNetUsers_ApplicationUserId",
                table: "Material_Prestamos",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Prestamos_AspNetUsers_ApplicationUserId",
                table: "Material_Prestamos");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Material_Prestamos",
                newName: "id_Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Material_Prestamos_ApplicationUserId",
                table: "Material_Prestamos",
                newName: "IX_Material_Prestamos_id_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Prestamos_AspNetUsers_id_Usuario",
                table: "Material_Prestamos",
                column: "id_Usuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
