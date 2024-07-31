using Microsoft.AspNetCore.Mvc;
using CloudBooks.API.Core.Services;
using CloudBooks.API.Presentation.ViewModel;

namespace CloudBooks.API.Presentation.Controllers
{
    [ApiController]
    [Route("v1/assuntos")]
    public class AssuntoController : ControllerBase
    {
        private readonly IAssuntoService _assuntoService;
        private readonly ILogger<AssuntoController> _logger;

        public AssuntoController(IAssuntoService assuntoService, ILogger<AssuntoController> logger)
        {
            _assuntoService = assuntoService;
            _logger = logger;
        }

        [HttpGet(Name = "GetAssuntos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var assuntos = await _assuntoService.GetAllAssuntosAsync();
                var assuntosView = assuntos.Select(a => new AssuntoViewModel(a.CodAs,a.Descricao)).ToList();
                return Ok(assuntosView);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao buscar todos os assuntos");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }

        [HttpPost(Name = "AddAssunto")]
        public async Task<IActionResult> Add(AssuntoViewModel assuntoView)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var assunto = new Assunto(assuntoView.Descricao);

                await _assuntoService.AddAssuntoAsync(assunto);

                return Ok(new { message = "Assunto criado com sucesso" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro na criação de assunto");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }

        [HttpDelete("{assuntoId}", Name = "RemoveAssunto")]
        public async Task<IActionResult> Remove(int assuntoId)
        {
            try
            {
                await _assuntoService.RemoveAssuntoAsync(assuntoId);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return StatusCode(404, new { message = "Assunto não encontrado" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro na deleção de assunto");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }

        [HttpPatch(Name = "UpdateAssunto")]
        public async Task<IActionResult> Update(AssuntoViewModel assuntoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var assunto = new Assunto(assuntoViewModel.CodAs, assuntoViewModel.Descricao);

                await _assuntoService.UpdateAssuntoAsync(assunto);

                return Ok(new { message = "Assunto atualizado com sucesso" });
            }
            catch (NotFoundException)
            {
                return StatusCode(404, new { message = "Assunto não encontrado" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro na atualização de assunto");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }
    }
}
