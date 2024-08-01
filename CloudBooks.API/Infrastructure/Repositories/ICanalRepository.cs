using CloudBooks.API.Core.Models;

namespace CloudBooks.API.Infrastructure.Repositories
{
    public interface ICanalRepository
    {
        Task<List<Canal>> GetAllAsync();
    }
}
