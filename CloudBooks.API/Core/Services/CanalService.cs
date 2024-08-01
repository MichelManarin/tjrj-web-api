using CloudBooks.API.Core.Models;
using CloudBooks.API.Infrastructure.Repositories;

namespace CloudBooks.API.Core.Services
{
    public class CanalService : ICanalService
    {
        private readonly ICanalRepository _canalRepository;

        public CanalService(ICanalRepository canalRepository)
        {
            _canalRepository = canalRepository;
        }

        public async Task<List<Canal>> GetAllAsync()
        {
            return await _canalRepository.GetAllAsync();
        }
    }
}
