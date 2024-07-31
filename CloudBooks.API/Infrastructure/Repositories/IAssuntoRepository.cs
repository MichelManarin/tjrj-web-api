namespace CloudBooks.API.Infrastructure.Repositories
{
    public interface IAssuntoRepository
    {
        Task AddAsync(Assunto assunto);
        Task DeleteAsync(Assunto assunto);
        Task UpdateAsync(Assunto assunto);
        Task<Assunto?> GetAsync(int assuntoId);
        Task<List<Assunto>> GetAllAsync();
    }
}
