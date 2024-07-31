namespace CloudBooks.API.Core.Services
{
    public interface IAutorService
    {
        Task<List<Autor>> GetAllAtoresAsync();
        Task AddAutorAsync(Autor autor);
        Task RemoveAutorAsync(int id);
        Task UpdateAutorAsync(Autor autor);
        Task<Autor?> GetAutorByIdAsync(int id);
    }
}
