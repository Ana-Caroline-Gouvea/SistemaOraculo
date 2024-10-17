using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oraculo.Migrations
{
    /// <inheritdoc />
    public partial class PostagemInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostagemImg",
                table: "Postagem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostagemNome",
                table: "Postagem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostagemImg",
                table: "Postagem");

            migrationBuilder.DropColumn(
                name: "PostagemNome",
                table: "Postagem");
        }
    }
}
