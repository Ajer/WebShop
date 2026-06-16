using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Caching.Distributed;

namespace WebShop.Views.Shared.Services
{
    // This class only for testing redis-caching in a WeatherController and is not used in the actual webshop application and can be removed.
    public class WeatherService
    {
        private readonly IDistributedCache _cache;

        private int updated;

        public WeatherService(IDistributedCache cache)
        {
            _cache = cache;
            updated = 0;     
        }

        // Cachar varje weatherforecast i 1 min
        public async Task<string> GetForecastAsync()
        {
            string cacheKey = "weather_forecast";
            string forecast = await _cache.GetStringAsync(cacheKey);

            if (forecast == null)   // ingen cachad data 
            {
                if (updated == 0)
                {
                    // Simulate fetching data from DB or external API
                    forecast = "Sunny, 25°C in Kalmar 🌞";
                }
                else
                {
                    forecast = "Cloudy, 18°C in Kalmar ☁️";
                }

                 var options = new DistributedCacheEntryOptions
                 {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                 };

                await _cache.SetStringAsync(cacheKey, forecast, options);   // Cachar data i Redis i 1 min
            }
            updated++;

            return forecast;
        }
    }
}
