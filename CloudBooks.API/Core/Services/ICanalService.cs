using CloudBooks.API.Core.Models;

namespace CloudBooks.API.Core.Services
{
    public interface ICanalService
    {
        Task<List<Canal>> GetAllAsync();

    }
}
