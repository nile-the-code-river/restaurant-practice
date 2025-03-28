using Microsoft.AspNetCore.Mvc;

namespace RestaurantsPractice.API.Controllers
{
    [ApiController]
    [Route("[controller]")] // api endpoint
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        [Route("example")]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _weatherForecastService.Get();
            return result;
        }
    }
}
