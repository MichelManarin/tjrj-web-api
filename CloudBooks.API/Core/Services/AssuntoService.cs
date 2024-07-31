using CloudBooks.API.Infrastructure.Repositories;

namespace CloudBooks.API.Core.Services
{
    public class AssuntoService : IAssuntoService
    {
        private readonly IAssuntoRepository _assuntoRepository;

        public AssuntoService(IAssuntoRepository assuntoRepository)
        {
            _assuntoRepository = assuntoRepository;
        }

        public async Task AddAssuntoAsync(Assunto assunto)
        {
            await _assuntoRepository.AddAsync(assunto);
        }

        public async Task<List<Assunto>> GetAllAssuntosAsync()
        {
            return await _assuntoRepository.GetAllAsync();
        }

        public async Task<Assunto?> GetAssuntoByIdAsync(int id)
        {
            return await _assuntoRepository.GetAsync(id);
        }

        public async Task RemoveAssuntoAsync(int id)
        {
            var autor = await _assuntoRepository.GetAsync(id);
            if (autor == null)
            {
                throw new NotFoundException("Assunto não encontrado!");
            }

            await _assuntoRepository.DeleteAsync(autor);
        }

        public async Task UpdateAssuntoAsync(Assunto assunto)
        {
            var autorUpd = await _assuntoRepository.GetAsync(assunto.CodAs);
            if (autorUpd == null)
            {
                throw new NotFoundException("Assunto não encontrado!");
            }

            await _assuntoRepository.UpdateAsync(assunto);
        }
    }
}
