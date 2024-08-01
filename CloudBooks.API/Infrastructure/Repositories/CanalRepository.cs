using CloudBooks.API.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudBooks.API.Infrastructure.Repositories
{
    public class CanalRepository : ICanalRepository
    {
        private readonly ConnectionContext _context;

        public CanalRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task<List<Canal>> GetAllAsync()
        {
           return await _context.Canais.ToListAsync();
        }
    }
}
