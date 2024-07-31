namespace CloudBooks.API.Infrastructure.Repositories
{
    public interface ILivroRepository
    {
        Task<int> AddAsync(Livro livro);
        Task DeleteAsync(Livro livro);
        Task UpdateAsync(Livro livro);
        Task<Livro?> GetAsync(int livroId);
        Task<IList<Autor>> GetAtoresAsync(int livroId);
        Task<IList<Assunto>> GetAssuntosAsync(int livroId);
        Task<List<Livro>> GetAllAsync();
        Task DeleteLink(Livro livro);
        Task AddLink(List<Livro_Assunto> livroAssunto, List<Livro_Autor> livroAutor);

    }
}
