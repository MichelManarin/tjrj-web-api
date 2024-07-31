namespace CloudBooks.API.Infrastructure.Repositories
{
    public interface IReportRepository
    {
        Task<IList<LivrosPorAutorViewModel>> GetAll();
    }
}
