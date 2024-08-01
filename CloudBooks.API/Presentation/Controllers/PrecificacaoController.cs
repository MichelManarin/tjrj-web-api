using Microsoft.AspNetCore.Mvc;
using CloudBooks.API.Core.Services;
using CloudBooks.API.Presentation.ViewModel;
using CloudBooks.API.Core.Models;

namespace CloudBooks.API.Presentation.Controllers
{
    [ApiController]
    [Route("v1/precificacoes")]
    public class PrecificacaoController : ControllerBase
    {
        private readonly IPrecificacaoService _precificacaoService;
        private readonly ILogger<PrecificacaoController> _logger;

        public PrecificacaoController(IPrecificacaoService precificacaoService, ILogger<PrecificacaoController> logger)
        {
            _precificacaoService = precificacaoService;
            _logger = logger;
        }

        [HttpGet(Name = "GetPrecificacoes")]
        public async Task<IActionResult> Get([FromQuery] int? codl)
        {
            try
            {
                var precificacoes = await _precificacaoService.GetAllAsync(codl);
                return Ok(precificacoes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao buscar todos os precificações");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }

        [HttpPost(Name = "AddPrecificacao")]
        public async Task<IActionResult> Add(PrecificacaoViewModel precificacaoView)
        {
            try
            {
                var precificacao = new Precificacao(null, precificacaoView.CodCa, precificacaoView.Codl, precificacaoView.Preco);
                await _precificacaoService.AddAsync(precificacao);
                return Ok(new { message = "Precificação criado com sucesso" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao criar precificação");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }
    }
}
