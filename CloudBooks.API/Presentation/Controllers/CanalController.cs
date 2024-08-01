using Microsoft.AspNetCore.Mvc;
using CloudBooks.API.Core.Services;
using CloudBooks.API.Presentation.ViewModel;

namespace CloudBooks.API.Presentation.Controllers
{
    [ApiController]
    [Route("v1/canais")]
    public class CanalController : ControllerBase
    {
        private readonly ICanalService _canalService;
        private readonly ILogger<CanalController> _logger;

        public CanalController(ICanalService canalService, ILogger<CanalController> logger)
        {
            _canalService = canalService;
            _logger = logger;
        }

        [HttpGet(Name = "GetCanais")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var canais = await _canalService.GetAllAsync();
                return Ok(canais);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao buscar todos os canais");
                return StatusCode(500, new { message = "Ocorreu um erro ao processar sua requisição. Tente novamente mais tarde" });
            }
        }
    }
}
