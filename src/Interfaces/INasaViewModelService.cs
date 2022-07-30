using NasaConsumer.Models;

namespace NasaConsumer.Interfaces
{
    public interface INasaViewModelService
    {
        Task<AsteroidsViewModel> GetAsteroidsByDateRangeAsync(DateTime startDate, DateTime? endDate);
        Task<IEnumerable<PicOfTheDayViewModel>> GetPicsOfTheDayAsync(DateTime startDate, DateTime endDate);
    }
}