using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudBooks.API.Migrations
{
    public partial class CreateViewForReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE VIEW LivrosPorAutorView AS
            SELECT
                a.Nome AS Autor,
                l.Titulo AS Livro,
                l.Editora,
                l.Edicao,
                l.AnoPublicacao,
                STRING_AGG(asd.Descricao, ', ') AS Assuntos
            FROM
                dbo.Livro_Autores la
                INNER JOIN dbo.Livros l ON la.Livro_Codl = l.Codl
                INNER JOIN dbo.Autores a ON la.Autor_CodAu = a.CodAu
                LEFT JOIN dbo.Livro_Assuntos las ON l.Codl = las.Livro_Codl
                LEFT JOIN dbo.Assuntos asd ON las.Assunto_CodAs = asd.CodAs
            GROUP BY
                a.Nome,
                l.Titulo,
                l.Editora,
                l.Edicao,
                l.AnoPublicacao;
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS LivrosPorAutorView;");
        }
    }
}
