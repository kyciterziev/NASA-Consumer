using System.Text.Json;
using NasaConsumer.Clients.Models;
using NasaConsumer.Exceptions;
using NasaConsumer.Utilities;

namespace NasaConsumer.Clients
{
    public class NasaClient : INasaClient
    {
        private readonly NasaClientConfig _config;

        public NasaClient(NasaClientConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task<AsteroidsResponse> GetAsteroidsByDateRangeAsync(DateTime startDate, DateTime? endDate)
        {
            var start = startDate.ToString("yyyy-MM-dd");
            var end = endDate?.ToString("yyyy-MM-dd");
            var queryString = QueryStringUtil.ToQueryString(new Dictionary<string, string>()
            {
                ["start_date"] = start,
                ["end_date"] = end,
            });

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_config.BaseUrl);
                var response = await client.GetAsync($"neo/rest/v1/feed?{queryString}&api_key={_config.ClientKey}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApiClientException("Not successful response");
                }

                var resStr = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(resStr))
                {
                    throw new ApiClientException("Invalid response");
                }

                return JsonSerializer.Deserialize<AsteroidsResponse>(resStr);
            }
        }

        public async Task<AstronomyPicResponse> GetAstronomyPicOfTheDayAsync(DateTime startDate, DateTime endDate)
        {
            var start = startDate.ToString("yyyy-MM-dd");
            var end = endDate.ToString("yyyy-MM-dd");
            string queryString = QueryStringUtil.ToQueryString(new Dictionary<string, string>()
            {
                ["start_date"] = start,
                ["end_date"] = end,
            });

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_config.BaseUrl);
                var response = await client.GetAsync($"planetary/apod?{queryString}&api_key={_config.ClientKey}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApiClientException("Not successful response");
                }

                var resStr = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(resStr))
                {
                    throw new ApiClientException("Invalid response");
                }

                var astronomyPics = JsonSerializer.Deserialize<IEnumerable<AstronomyPic>>(resStr); ;
                return new AstronomyPicResponse
                {
                    AstronomyPics = astronomyPics
                };
            }
        }
    }
}