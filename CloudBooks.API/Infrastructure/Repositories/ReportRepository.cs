using Microsoft.EntityFrameworkCore;

namespace CloudBooks.API.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ConnectionContext _context;

        public ReportRepository(ConnectionContext context)
        {
            _context = context;
        }
        public async Task<IList<LivrosPorAutorViewModel>> GetAll()
        {
            return await _context.LivrosPorAutorView.ToListAsync();
        }
    }
}
