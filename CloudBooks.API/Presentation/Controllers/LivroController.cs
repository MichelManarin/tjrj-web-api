using CloudBooks.API.Core.Services;
using CloudBooks.API.Presentation.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CloudBooks.API.Presentation.Controllers
{
    [ApiController]
    [Route("v1/livros")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;
        private readonly ILogger<LivroController> _logger;

        public LivroController(ILivroService livroService, ILogger<LivroController> logger)
        {
            _livroService = livroService;
            _logger = logger;
        }

        [HttpGet(Name = "GetLivros")]
        public async Task<IActionResult> GetLivros()
        {
            try
            {
                var livros = await _livroService.GetAllLivrosAsync();

                var livrosView = livros.Select(l => new LivroViewModel(
                    l.Codl,
                    l.Titulo,
                    l.Editora,
                    l.Edicao,
                    l.AnoPublicacao,
                    l.Livro_Assuntos.Select(ls => ls.Assunto).ToList(),
                    l.Livro_Autores.Select(la => la.Autor).ToList()
                )).ToList();

                return Ok(livrosView);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao buscar todos os livros");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }

        [HttpPost(Name = "AddLivro")]
        public async Task<IActionResult> Add(LivroViewModel livroView)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var livro = new Livro(livroView.Titulo, livroView.Editora, livroView.Edicao, livroView.AnoPublicacao);

                var newId = await _livroService.AddLivroAsync(livro);

                var livroAutores = livroView.AutoresIds.Select(id => new Livro_Autor { Livro_Codl = newId, Autor_CodAu = id }).ToList();
                var livroAssuntos = livroView.AssuntosIds.Select(id => new Livro_Assunto { Livro_Codl = newId, Assunto_CodAs = id }).ToList();

                await _livroService.AddLivroAssuntoAndLivroAutor(livroAssuntos, livroAutores);

                return Ok(new { message = "Livro criado com sucesso" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro na criação de livro");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }

        [HttpDelete("{livroId}", Name = "RemoveLivro")]
        public async Task<IActionResult> Remove(int livroId)
        {
            try
            {
                await _livroService.RemoveLivroAsync(livroId);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return StatusCode(404, new { message = "Livro não encontrado" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro na deleção de livro");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }

        [HttpPatch(Name = "UpdateLivro")]
        public async Task<IActionResult> Update(LivroViewModel livroView)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var livro = new Livro(livroView.Codl, livroView.Titulo, livroView.Editora, livroView.Edicao, livroView.AnoPublicacao);

                var livroAutores = livroView.AutoresIds.Select(id => new Livro_Autor { Livro_Codl = livroView.Codl, Autor_CodAu = id }).ToList();
                var livroAssuntos = livroView.AssuntosIds.Select(id => new Livro_Assunto { Livro_Codl = livroView.Codl, Assunto_CodAs = id }).ToList();

                await _livroService.UpdateLivroAsync(livro);
                await _livroService.RemoveLivroAssuntoAndLivroAutor(livro.Codl);
                await _livroService.AddLivroAssuntoAndLivroAutor(livroAssuntos, livroAutores);

                return Ok(new { message = "Livro atualizado com sucesso" });
            }
            catch (NotFoundException)
            {
                return StatusCode(404, new { message = "Livro não encontrado" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro na atualização de livro");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }
    }
}