using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoClaudia.Migrations
{
    /// <inheritdoc />
    public partial class corrigindoRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_TipoUsuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Id_Produto",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "Id_Usuario",
                table: "Compra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_TipoUsuario",
                table: "Usuario",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Produto",
                table: "Compra",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Usuario",
                table: "Compra",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
