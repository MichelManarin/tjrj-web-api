namespace CloudBooks.API.Core.Services
{
    public interface ILivroService
    {
        Task<List<Livro>> GetAllLivrosAsync();
        Task<int> AddLivroAsync(Livro livro);
        Task RemoveLivroAsync(int id);
        Task UpdateLivroAsync(Livro livro);
        Task<Livro?> GetLivroByIdAsync(int id);
        Task AddLivroAssuntoAndLivroAutor(List<Livro_Assunto> livroAssunto, List<Livro_Autor> livroAutor);
        //Task<Livro?> RemoveLivroAssuntoAndLivroAutor(int livroId);
    }
}