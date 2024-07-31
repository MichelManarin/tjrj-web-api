namespace CloudBooks.API.Infrastructure.Repositories
{
    public interface IAutorRepository
    {
        Task AddAsync(Autor autor);
        Task DeleteAsync(Autor autor);
        Task UpdateAsync(Autor autor);
        Task<Autor?> GetAsync(int autorId);
        Task<List<Autor>> GetAllAsync();
    }
}
