using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudBooks.API.Migrations
{
    public partial class AdicionarValoresPadraoCanal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Canais",
            columns: new[] { "CodCa", "Nome" },
            values: new object[,]
            {
                { 1, "Lojas Virtuais" },
                { 2, "Lojas Físicas" },
                { 3, "Eventos" },
                { 4, "Self-service" }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "Canais",
            keyColumn: "CodCa",
            keyValues: new object[] { 1, 2, 3, 4 });
        }
    }
}
