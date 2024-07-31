using Microsoft.EntityFrameworkCore;

namespace CloudBooks.API.Infrastructure.Repositories
{
    public class AssuntoRepository : IAssuntoRepository
    {
        private readonly ConnectionContext _context;

        public AssuntoRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Assunto assunto)
        {
            await _context.Assuntos.AddAsync(assunto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Assunto assunto)
        {
            _context.Assuntos.Remove(assunto);
            await _context.SaveChangesAsync();
        }

        public async Task<Assunto?> GetAsync(int assuntoId)
        {
            return await _context.Assuntos.AsNoTracking().FirstOrDefaultAsync(p => p.CodAs == assuntoId);
        }

        public async Task<List<Assunto>> GetAllAsync()
        {
            return await _context.Assuntos.AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(Assunto assunto)
        {
            _context.Assuntos.Update(assunto);
            await _context.SaveChangesAsync();
        }
    }
}