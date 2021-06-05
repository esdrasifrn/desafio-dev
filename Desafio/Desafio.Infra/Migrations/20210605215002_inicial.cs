using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Infra.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loja",
                columns: table => new
                {
                    LojaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dono = table.Column<string>(type: "varchar(50)", nullable: true),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loja", x => x.LojaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoTransacao",
                columns: table => new
                {
                    TipoTransacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: true),
                    Natureza = table.Column<string>(type: "varchar(50)", nullable: true),
                    Sinal = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransacao", x => x.TipoTransacaoId);
                });

            migrationBuilder.CreateTable(
                name: "TransacaoItem",
                columns: table => new
                {
                    TransacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "Decimal(15,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CpfBeneficiario = table.Column<string>(type: "varchar(15)", nullable: true),
                    LojaId = table.Column<int>(type: "int", nullable: true),
                    Cartao = table.Column<string>(type: "varchar(20)", nullable: true),
                    TipoTransacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacaoItem", x => x.TransacaoId);
                    table.ForeignKey(
                        name: "FK_TransacaoItem_Loja_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Loja",
                        principalColumn: "LojaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransacaoItem_TipoTransacao_TipoTransacaoId",
                        column: x => x.TipoTransacaoId,
                        principalTable: "TipoTransacao",
                        principalColumn: "TipoTransacaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TipoTransacao",
                columns: new[] { "TipoTransacaoId", "Descricao", "Natureza", "Sinal" },
                values: new object[,]
                {
                    { 1, "Débito", "Entrada", "+" },
                    { 2, "Boleto", "Saída", "-" },
                    { 3, "Financiamento", "Saída", "-" },
                    { 4, "Crédito", "Entrada", "+" },
                    { 5, "Recebimento Empréstimo", "Entrada", "+" },
                    { 6, "Vendas", "Entrada", "+" },
                    { 7, "Recebimento TED", "Entrada", "+" },
                    { 8, "Recebimento DOC", "Entrada", "+" },
                    { 9, "Aluguel", "Saída", "-" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransacaoItem_LojaId",
                table: "TransacaoItem",
                column: "LojaId");

            migrationBuilder.CreateIndex(
                name: "IX_TransacaoItem_TipoTransacaoId",
                table: "TransacaoItem",
                column: "TipoTransacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransacaoItem");

            migrationBuilder.DropTable(
                name: "Loja");

            migrationBuilder.DropTable(
                name: "TipoTransacao");
        }
    }
}
