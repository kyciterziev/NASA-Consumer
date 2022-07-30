using NasaConsumer.Clients.Models;

namespace NasaConsumer.Interfaces
{
    public interface INasaService
    {
        Task<AsteroidsResponse> GetAsteroidsByDateRangeAsync(DateTime startDate, DateTime? endDate);
        Task<byte[]> GetAsteroidsExcelDataToByteArrayAsync(DateTime startDate, DateTime? endDate);
    }
}