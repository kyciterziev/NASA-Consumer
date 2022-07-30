using NasaConsumer.Clients;
using NasaConsumer.Interfaces;
using NasaConsumer.Models;

namespace NasaConsumer.Services
{

    public class NasaViewModelService : INasaViewModelService
    {
        private readonly INasaClient _nasaClient;

        public NasaViewModelService(INasaClient nasaClient)
        {
            _nasaClient = nasaClient ?? throw new ArgumentNullException(nameof(nasaClient));
        }

        public async Task<AsteroidsViewModel> GetAsteroidsByDateRangeAsync(DateTime startDate, DateTime? endDate)
        {
            var asteroids = await _nasaClient.GetAsteroidsByDateRangeAsync(startDate, endDate);

            return new AsteroidsViewModel
            {
                StartDate = startDate,
                EndDate = endDate,
                Asteroids = asteroids
            };
        }

        public async Task<IEnumerable<PicOfTheDayViewModel>> GetPicsOfTheDayAsync(DateTime startDate, DateTime endDate)
        {
            var picsOfTheDay = await _nasaClient.GetAstronomyPicOfTheDayAsync(startDate, endDate);
            return picsOfTheDay.AstronomyPics
                .Select(x => new PicOfTheDayViewModel()
                {
                    Copyright = x.Copyright,
                    Date = x.Date.Date,
                    Explanation = x.Explanation,
                    Title = x.Title,
                    Url = x.Url
                });
        }
    }
}