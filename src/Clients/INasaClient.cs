using NasaConsumer.Clients.Models;

namespace NasaConsumer.Clients
{
    public interface INasaClient
    {
        Task<AsteroidsResponse> GetAsteroidsByDateRangeAsync(DateTime startDate, DateTime? endDate);
        Task<AstronomyPicResponse> GetAstronomyPicOfTheDayAsync(DateTime startDate, DateTime endDate);
    }
}