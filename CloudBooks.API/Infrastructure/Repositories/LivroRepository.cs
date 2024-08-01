
using Microsoft.EntityFrameworkCore;

namespace CloudBooks.API.Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ConnectionContext _context;

        public LivroRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return livro.Codl;
        }

        public async Task AddLink(List<Livro_Assunto>livroAssunto, List<Livro_Autor> livroAutor)
        {
            _context.Livro_Autores.AddRange(livroAutor);
            _context.Livro_Assuntos.AddRange(livroAssunto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Livro livro)
        {
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLink(Livro livro)
        {
            var livroAssuntos = _context.Livro_Assuntos.Where(la => la.Livro_Codl == livro.Codl);
            _context.Livro_Assuntos.RemoveRange(livroAssuntos);

            var livroAutores = _context.Livro_Autores.Where(la => la.Livro_Codl == livro.Codl);
            _context.Livro_Autores.RemoveRange(livroAutores);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Livro>> GetAllAsync()
        {
            return await _context.Livros
               .Include(l => l.Livro_Autores)
               .ThenInclude(la => la.Autor)
               .Include(l => l.Livro_Assuntos)
               .ThenInclude(ls => ls.Assunto)
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<Livro?> GetAsync(int livroId)
        {
            return await _context.Livros
                .Include(l => l.Livro_Autores)
                .Include(l => l.Livro_Assuntos)
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Codl == livroId);
        }
        public async Task<IList<Autor>> GetAtoresAsync(int livroId)
        {
            return await _context.Livros
                .Where(l => l.Codl == livroId)
                .SelectMany(l => l.Livro_Autores)
                .Select(la => la.Autor)
                .ToListAsync();
        }
        public async Task<IList<Assunto>> GetAssuntosAsync(int livroId)
        {
            return await _context.Livros
                .Where(l => l.Codl == livroId)
                .SelectMany(l => l.Livro_Assuntos)
                .Select(la => la.Assunto)
                .ToListAsync();
        }


        public async Task UpdateAsync(Livro livro)
        {
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();
        }
    }
}
