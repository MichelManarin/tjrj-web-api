using Microsoft.EntityFrameworkCore;

namespace CloudBooks.API.Infrastructure.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly ConnectionContext _context;

        public AutorRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Autor autor)
        {
            await _context.Autores.AddAsync(autor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Autor autor)
        {
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
        }

        public async Task<Autor?> GetAsync(int autorId)
        {
            return await _context.Autores.AsNoTracking().FirstOrDefaultAsync(a => a.CodAu == autorId);
        }

        public async Task<List<Autor>> GetAllAsync()
        {
            return await _context.Autores.AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(Autor autor)
        {
            _context.Autores.Update(autor);
            await _context.SaveChangesAsync();
        }
    }
}
