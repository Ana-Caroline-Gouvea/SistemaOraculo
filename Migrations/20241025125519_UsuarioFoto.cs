using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oraculo.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioFoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioFoto",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioFoto",
                table: "Usuario");
        }
    }
}
