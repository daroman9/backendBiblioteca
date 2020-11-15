using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendBiblioteca.Migrations
{
    public partial class DeleteIdUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Prestamos_AspNetUsers_ApplicationUserId",
                table: "Material_Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Material_Prestamos_ApplicationUserId",
                table: "Material_Prestamos");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Material_Prestamos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Material_Prestamos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_Prestamos_ApplicationUserId",
                table: "Material_Prestamos",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Prestamos_AspNetUsers_ApplicationUserId",
                table: "Material_Prestamos",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
