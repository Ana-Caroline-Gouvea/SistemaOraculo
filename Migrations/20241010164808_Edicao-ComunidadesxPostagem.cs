using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oraculo.Migrations
{
    /// <inheritdoc />
    public partial class EdicaoComunidadesxPostagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postagem_Comunidades_ComunidadesId",
                table: "Postagem");

            migrationBuilder.DropColumn(
                name: "ComunidadeId",
                table: "Postagem");

            migrationBuilder.AlterColumn<int>(
                name: "ComunidadesId",
                table: "Postagem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Postagem_Comunidades_ComunidadesId",
                table: "Postagem",
                column: "ComunidadesId",
                principalTable: "Comunidades",
                principalColumn: "ComunidadesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postagem_Comunidades_ComunidadesId",
                table: "Postagem");

            migrationBuilder.AlterColumn<int>(
                name: "ComunidadesId",
                table: "Postagem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ComunidadeId",
                table: "Postagem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Postagem_Comunidades_ComunidadesId",
                table: "Postagem",
                column: "ComunidadesId",
                principalTable: "Comunidades",
                principalColumn: "ComunidadesId");
        }
    }
}
