using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlStockWebApp.Migrations
{
    public partial class removendotableestoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entradas_estoques_EstoqueId",
                table: "entradas");

            migrationBuilder.DropForeignKey(
                name: "FK_saidas_estoques_EstoqueId",
                table: "saidas");

            migrationBuilder.DropTable(
                name: "estoques");

            migrationBuilder.DropIndex(
                name: "IX_saidas_EstoqueId",
                table: "saidas");

            migrationBuilder.DropIndex(
                name: "IX_entradas_EstoqueId",
                table: "entradas");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "saidas");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "entradas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstoqueId",
                table: "saidas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstoqueId",
                table: "entradas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "estoques",
                columns: table => new
                {
                    EstoqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Estoque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total_Estoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estoques", x => x.EstoqueId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_saidas_EstoqueId",
                table: "saidas",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_entradas_EstoqueId",
                table: "entradas",
                column: "EstoqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_entradas_estoques_EstoqueId",
                table: "entradas",
                column: "EstoqueId",
                principalTable: "estoques",
                principalColumn: "EstoqueId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_saidas_estoques_EstoqueId",
                table: "saidas",
                column: "EstoqueId",
                principalTable: "estoques",
                principalColumn: "EstoqueId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
