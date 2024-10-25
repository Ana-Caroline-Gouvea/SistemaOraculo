using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oraculo.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Postagem",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Postagem_UsuarioId",
                table: "Postagem",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Postagem_Usuario_UsuarioId",
                table: "Postagem",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postagem_Usuario_UsuarioId",
                table: "Postagem");

            migrationBuilder.DropIndex(
                name: "IX_Postagem_UsuarioId",
                table: "Postagem");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Postagem");
        }
    }
}
