using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoClaudia.Migrations
{
    /// <inheritdoc />
    public partial class urlImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL_Imagem",
                table: "Produto",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL_Imagem",
                table: "Produto");
        }
    }
}
