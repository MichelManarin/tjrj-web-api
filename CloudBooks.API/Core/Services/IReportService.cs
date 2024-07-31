namespace CloudBooks.API.Core.Services
{
    public interface IReportService
    {
        Task<byte[]> generateBufferReport();
    }
}
