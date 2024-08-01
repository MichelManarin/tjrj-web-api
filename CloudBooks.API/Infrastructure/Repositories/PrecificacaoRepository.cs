using CloudBooks.API.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudBooks.API.Infrastructure.Repositories
{
    public class PrecificacaoRepository : IPrecificacaoRepository
    {
        private readonly ConnectionContext _context;

        public PrecificacaoRepository(ConnectionContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Precificacao precificacao)
        {
            await _context.Precificacoes.AddAsync(precificacao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Precificacao>> GetAllAsync()
        {
            return await _context.Precificacoes
               .Include(l => l.CanalVenda)
               .AsNoTracking()
               .ToListAsync();
        }
    }
}
