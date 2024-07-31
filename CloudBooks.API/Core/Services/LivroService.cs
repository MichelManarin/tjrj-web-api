
using CloudBooks.API.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CloudBooks.API.Core.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task AddLivroAssuntoAndLivroAutor(List<Livro_Assunto> livroAssunto, List<Livro_Autor> livroAutor)
        {
            await _livroRepository.AddLink(livroAssunto, livroAutor);
        }

        public async Task<int> AddLivroAsync(Livro livro)
        {
            return await _livroRepository.AddAsync(livro);
        }

        public async Task<List<Livro>> GetAllLivrosAsync()
        {
            return await _livroRepository.GetAllAsync();
        }

        public async Task<Livro?> GetLivroByIdAsync(int id)
        {
            return await _livroRepository.GetAsync(id);
        }

        public Task<Livro?> RemoveLivroAssuntoAndLivroAutor(int livroId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveLivroAsync(int id)
        {
            var livro = await _livroRepository.GetAsync(id);
            if (livro == null)
            {
                throw new NotFoundException("Livro não encontrado!");
            }

            await _livroRepository.DeleteAsync(livro);
        }

        public async Task UpdateLivroAsync(Livro livro)
        {
            var livroUpd = await _livroRepository.GetAsync(livro.Codl);
            if (livroUpd == null)
            {
                throw new NotFoundException("Livro não encontrado!");
            }

            await _livroRepository.UpdateAsync(livro); 
        }
    }
}
