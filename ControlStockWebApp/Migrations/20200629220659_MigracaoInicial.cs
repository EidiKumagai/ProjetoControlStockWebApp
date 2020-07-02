using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlStockWebApp.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Cliente = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    CpforCnpj = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "estoques",
                columns: table => new
                {
                    EstoqueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Estoque = table.Column<string>(nullable: true),
                    Total_Estoque = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estoques", x => x.EstoqueId);
                });

            migrationBuilder.CreateTable(
                name: "fornecedores",
                columns: table => new
                {
                    FornecedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Fornecedor = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    CpforCnpj = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedores", x => x.FornecedorId);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Produto = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Preco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "entradas",
                columns: table => new
                {
                    EntradaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Entrada = table.Column<string>(nullable: true),
                    FornecedorId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    qtde_Entrada = table.Column<int>(nullable: false),
                    EstoqueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entradas", x => x.EntradaId);
                    table.ForeignKey(
                        name: "FK_entradas_estoques_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "estoques",
                        principalColumn: "EstoqueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_entradas_fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "fornecedores",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_entradas_produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "saidas",
                columns: table => new
                {
                    SaidaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Saida = table.Column<string>(nullable: true),
                    Qtde_Saida = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    EstoqueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saidas", x => x.SaidaId);
                    table.ForeignKey(
                        name: "FK_saidas_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_saidas_estoques_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "estoques",
                        principalColumn: "EstoqueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_saidas_produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_entradas_EstoqueId",
                table: "entradas",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_entradas_FornecedorId",
                table: "entradas",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_entradas_ProdutoId",
                table: "entradas",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_saidas_ClienteId",
                table: "saidas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_saidas_EstoqueId",
                table: "saidas",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_saidas_ProdutoId",
                table: "saidas",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entradas");

            migrationBuilder.DropTable(
                name: "saidas");

            migrationBuilder.DropTable(
                name: "fornecedores");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "estoques");

            migrationBuilder.DropTable(
                name: "produtos");
        }
    }
}
