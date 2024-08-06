using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudBooks.API.Migrations
{
    public partial class FixViewForReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR ALTER VIEW LivrosPorAutorView AS
                    WITH LivroAssuntos AS (
                        SELECT
                            l.Codl,
                            l.Titulo,
                            l.Editora,
                            l.Edicao,
                            l.AnoPublicacao,
                            STRING_AGG(COALESCE(asd.Descricao, 'Nenhum'), ', ') AS Assuntos
                        FROM
                            dbo.Livros l
                            LEFT JOIN dbo.Livro_Assuntos las ON l.Codl = las.Livro_Codl
                            LEFT JOIN dbo.Assuntos asd ON las.Assunto_CodAs = asd.CodAs
                        GROUP BY
                            l.Codl, l.Titulo, l.Editora, l.Edicao, l.AnoPublicacao
                    ),
                    AutorLivros AS (
                        SELECT
                            a.Nome AS Autor,
                            l.Codl,
                            l.Titulo,
                            l.Editora,
                            l.Edicao,
                            l.AnoPublicacao,
                            l.Assuntos
                        FROM
                            dbo.Autores a
                            INNER JOIN dbo.Livro_Autores la ON a.CodAu = la.Autor_CodAu
                            INNER JOIN LivroAssuntos l ON la.Livro_Codl = l.Codl
                    )
                    SELECT
                        Autor,
                        STRING_AGG(Titulo + ' (Editora: ' + Editora + ', Edição: ' + CAST(Edicao AS VARCHAR) + ', Ano: ' + CAST(AnoPublicacao AS VARCHAR) + ')', CHAR(13) + CHAR(10)) AS Livros,
                        STRING_AGG(Assuntos, ', ') AS Assuntos
                    FROM
                        AutorLivros
                    GROUP BY
                        Autor;
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS LivrosPorAutorView;");
        }
    }
}
