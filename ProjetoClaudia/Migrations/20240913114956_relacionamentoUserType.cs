using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoClaudia.Migrations
{
    /// <inheritdoc />
    public partial class relacionamentoUserType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_TipoUsuario",
                table: "Usuario",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoUsuarioId",
                table: "Usuario",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Des_TipoUsuario = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoUsuarioId",
                table: "Usuario",
                column: "TipoUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_TipoUsuario_TipoUsuarioId",
                table: "Usuario",
                column: "TipoUsuarioId",
                principalTable: "TipoUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_TipoUsuario_TipoUsuarioId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_TipoUsuarioId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Id_TipoUsuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "TipoUsuarioId",
                table: "Usuario");
        }
    }
}
