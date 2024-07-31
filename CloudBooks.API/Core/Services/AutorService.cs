using CloudBooks.API.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.Design;

namespace CloudBooks.API.Core.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task AddAutorAsync(Autor autor)
        {
            await _autorRepository.AddAsync(autor);
        }

        public async Task<List<Autor>> GetAllAtoresAsync()
        {
            return await _autorRepository.GetAllAsync();
        }

        public async Task<Autor?> GetAutorByIdAsync(int id)
        {
            return await _autorRepository.GetAsync(id);
        }

        public async Task RemoveAutorAsync(int id)
        {
            var autor = await _autorRepository.GetAsync(id);
            if (autor == null)
            {
                throw new NotFoundException("Autor não encontrado!");
            }

            await _autorRepository.DeleteAsync(autor);
        }

        public async Task UpdateAutorAsync(Autor autor)
        {
            var autorUpd = await _autorRepository.GetAsync(autor.CodAu);
            if (autorUpd == null)
            {
                throw new NotFoundException("Autor não encontrado!");
            }

            await _autorRepository.UpdateAsync(autor);
        }
    }
}
