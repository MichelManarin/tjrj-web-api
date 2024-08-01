using CloudBooks.API.Core.Models;

namespace CloudBooks.API.Infrastructure.Repositories
{
    public interface IPrecificacaoRepository
    {
        Task AddAsync(Precificacao precificacao);
        Task<List<Precificacao>> GetAllAsync();
    }
}
