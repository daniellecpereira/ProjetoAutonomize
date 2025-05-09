using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autonomize.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIDUsuarioFromProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Usuarios_IDUsuario",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_IDUsuario",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IDUsuario",
                table: "Produtos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDUsuario",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IDUsuario",
                table: "Produtos",
                column: "IDUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Usuarios_IDUsuario",
                table: "Produtos",
                column: "IDUsuario",
                principalTable: "Usuarios",
                principalColumn: "IDUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
