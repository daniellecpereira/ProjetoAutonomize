using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autonomize.Migrations
{
    /// <inheritdoc />
    public partial class M03_ItensVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItensVenda",
                columns: table => new
                {
                    IDItemVenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVenda = table.Column<int>(type: "int", nullable: false),
                    IDProduto = table.Column<int>(type: "int", nullable: false),
                    QuantidadeVendida = table.Column<int>(type: "int", nullable: false),
                    PrecoProduto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVenda", x => x.IDItemVenda);
                    table.ForeignKey(
                        name: "FK_ItensVenda_Produtos_IDProduto",
                        column: x => x.IDProduto,
                        principalTable: "Produtos",
                        principalColumn: "IDProduto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensVenda_Vendas_IDVenda",
                        column: x => x.IDVenda,
                        principalTable: "Vendas",
                        principalColumn: "IDVenda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_IDProduto",
                table: "ItensVenda",
                column: "IDProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_IDVenda",
                table: "ItensVenda",
                column: "IDVenda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensVenda");
        }
    }
}
