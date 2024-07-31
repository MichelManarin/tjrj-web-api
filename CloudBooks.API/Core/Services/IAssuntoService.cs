namespace CloudBooks.API.Core.Services
{
    public interface IAssuntoService
    {
        Task<List<Assunto>> GetAllAssuntosAsync();
        Task AddAssuntoAsync(Assunto assunto);
        Task RemoveAssuntoAsync(int id);
        Task UpdateAssuntoAsync(Assunto assunto);
        Task<Assunto?> GetAssuntoByIdAsync(int id);
    }
}
