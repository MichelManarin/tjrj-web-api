using Microsoft.AspNetCore.Mvc;
using CloudBooks.API.Core.Services;
using CloudBooks.API.Presentation.ViewModel;

namespace CloudBooks.API.Presentation.Controllers
{
    [ApiController]
    [Route("v1/autores")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;
        private readonly ILogger<AutorController> _logger;

        public AutorController(IAutorService autorService, ILogger<AutorController> logger)
        {
            _autorService = autorService;
            _logger = logger;
        }

        [HttpGet(Name = "GetAtores")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var autores = await _autorService.GetAllAtoresAsync();

                var autoresView = autores.Select(a => new AutorViewModel(a.CodAu, a.Nome)).ToList();

                return Ok(autoresView);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao buscar todos os atores");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }

        [HttpPost(Name = "AddAtore")]
        public async Task<IActionResult> Add(AutorViewModel autorView)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var ator = new Autor(autorView.Nome);

                await _autorService.AddAutorAsync(ator);

                return Ok(new { message = "Ator criado com sucesso" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro na criação de ator");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }

        [HttpDelete("{atorId}", Name = "RemoveAutor")]
        public async Task<IActionResult> Remove(int atorId)
        {
            try
            {
                await _autorService.RemoveAutorAsync(atorId);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return StatusCode(404, new { message = "Ator não encontrado" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro na deleção de ator");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }

        [HttpPatch(Name = "UpdateAtor")]
        public async Task<IActionResult> Update(AutorViewModel assuntoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var autor = new Autor(assuntoViewModel.CodAu, assuntoViewModel.Nome);

                await _autorService.UpdateAutorAsync(autor);

                return Ok(new { message = "Autor atualizado com sucesso" });
            }
            catch (NotFoundException)
            {
                return StatusCode(404, new { message = "Autor não encontrado" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro na atualização de autor");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }
    }
}
