using Microsoft.AspNetCore.Mvc;
using WebShop.Views.Shared.Services;


// This controller is only used to test caching with Redis on the WeatherService and is not used in the actual webshop application and can be removed.

namespace WebShop.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("Weather/Get")]   // /Weather/Get
        public async Task<IActionResult> Get()
        {
            var forecast = await _weatherService.GetForecastAsync();
            ViewData["Forecast"] = forecast;

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
