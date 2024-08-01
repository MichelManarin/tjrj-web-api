using CloudBooks.API.Core.Models;

namespace CloudBooks.API.Core.Services
{
    public interface IPrecificacaoService
    {
        Task<List<Precificacao>> GetAllAsync();
        Task AddAsync(Precificacao precificacao);
        
    }
}
