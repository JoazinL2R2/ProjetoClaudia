using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoClaudia.Migrations
{
    /// <inheritdoc />
    public partial class CarrinhoPt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Flg_Inativo",
                table: "Carrinho",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flg_Inativo",
                table: "Carrinho");
        }
    }
}
