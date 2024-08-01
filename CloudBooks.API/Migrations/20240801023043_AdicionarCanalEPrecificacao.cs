using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudBooks.API.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCanalEPrecificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canais",
                columns: table => new
                {
                    CodCa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canais", x => x.CodCa);
                });

            migrationBuilder.CreateTable(
                name: "Precificacoes",
                columns: table => new
                {
                    CodPr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCa = table.Column<int>(type: "int", nullable: false),
                    Codl = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precificacoes", x => x.CodPr);
                    table.ForeignKey(
                        name: "FK_Precificacoes_Canais_CodCa",
                        column: x => x.CodCa,
                        principalTable: "Canais",
                        principalColumn: "CodCa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Precificacoes_Livros_Codl",
                        column: x => x.Codl,
                        principalTable: "Livros",
                        principalColumn: "Codl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Precificacoes_CodCa",
                table: "Precificacoes",
                column: "CodCa");

            migrationBuilder.CreateIndex(
                name: "IX_Precificacoes_Codl",
                table: "Precificacoes",
                column: "Codl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Precificacoes");

            migrationBuilder.DropTable(
                name: "Canais");
        }
    }
}
