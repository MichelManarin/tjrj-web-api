using CloudBooks.API.Core.Models;
using CloudBooks.API.Infrastructure.Repositories;

namespace CloudBooks.API.Core.Services
{
    public class PrecificacaoService : IPrecificacaoService
    {
        private readonly IPrecificacaoRepository _precificacaoRepository;

        public PrecificacaoService(IPrecificacaoRepository precificacaoRepository)
        {
            _precificacaoRepository = precificacaoRepository;
        }

        public async Task AddAsync(Precificacao precificacao)
        {
            await _precificacaoRepository.AddAsync(precificacao);
        }

        public async Task<List<Precificacao>> GetAllAsync(int? codl)
        {
            return await _precificacaoRepository.GetAllAsync(codl);
        }
    }
}
