using CloudBooks.API.Infrastructure.Repositories;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CloudBooks.API.Core.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<byte[]> generateBufferReport()
        {
            var linhas = await _reportRepository.GetAll();

            using (var memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4);
                using (var writer = PdfWriter.GetInstance(document, memoryStream))
                {
                    document.Open();

                    var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                    var headerPhrase = new Phrase("Relatório de Livros por Autor", boldFont);

                    document.Add(headerPhrase);

                    var table = new PdfPTable(6); 

                    float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f };
                    table.SetWidths(widths);

                    table.AddCell(new Phrase("Autor", boldFont));
                    table.AddCell(new Phrase("Livro", boldFont));
                    table.AddCell(new Phrase("Editora", boldFont));
                    table.AddCell(new Phrase("Edição", boldFont));
                    table.AddCell(new Phrase("Ano de publicação", boldFont));
                    table.AddCell(new Phrase("Assuntos", boldFont));

                    foreach (var linha in linhas)
                    {
                        addRow(table, linha.Autor, linha.Livro, linha.Editora, linha.Edicao, linha.AnoPublicacao, linha.Assuntos);
                    }

                    document.Add(table);

                    document.Close(); 

                    var pdfBytes = memoryStream.ToArray();

                    return pdfBytes;                   
                }
            }
        }
        private void addRow(PdfPTable table, string autor, string livro, string editora, int edicao, string anoPublicacao, string assuntos)
        {
            table.AddCell(autor);
            table.AddCell(livro);
            table.AddCell(editora);
            table.AddCell(edicao.ToString());
            table.AddCell(anoPublicacao);
            table.AddCell(assuntos);
        }

    }
}
