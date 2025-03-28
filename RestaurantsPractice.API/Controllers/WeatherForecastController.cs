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
        [Route("{take}/example")]
        public IEnumerable<WeatherForecast> Get([FromQuery] int max, [FromRoute] int take)
        {
            var result = _weatherForecastService.Get();
            return result;
        }

        [HttpGet]
        [Route("currentDay")]
        public IActionResult GetCurrentDay()
        {
            var result = _weatherForecastService.Get().First();
            //return StatusCode(400, result);
            return BadRequest(result);
        }

        [HttpPost]
        public string Hello([FromBody] string name)
        {
            return $"Hello {name}";
        }
    }
}
