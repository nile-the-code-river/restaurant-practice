using Microsoft.AspNetCore.Mvc;

namespace RestaurantsPractice.API.Controllers
{
    [ApiController]
    [Route("[controller]")] // api endpoint
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastService _weatherForecastService = new();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
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
