using CloudBooks.API.Core.Services;
using CloudBooks.API.Presentation.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CloudBooks.API.Presentation.Controllers
{
    [ApiController]
    [Route("v1/relatorios")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IReportService _reportService;
        public ReportController(ILogger<ReportController> logger, IReportService reportService)
        {
            _reportService = reportService;
            _logger = logger;
        }

        [HttpGet(Name = "GetReport")]
        public async Task<IActionResult> GetReport()
        {
            try
            {
                var pdfBytes = await _reportService.generateBufferReport();

                return File(pdfBytes, "application/pdf", "report.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao buscar todos os livros");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }

        }

    }
}
