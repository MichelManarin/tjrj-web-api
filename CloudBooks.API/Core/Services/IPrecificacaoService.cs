using CloudBooks.API.Core.Models;

namespace CloudBooks.API.Core.Services
{
    public interface IPrecificacaoService
    {
        Task<List<Precificacao>> GetAllAsync(int? codl);
        Task AddAsync(Precificacao precificacao);
        
    }
}
