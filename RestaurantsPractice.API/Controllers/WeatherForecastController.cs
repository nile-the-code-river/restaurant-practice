using Microsoft.AspNetCore.Mvc;

namespace RestaurantsPractice.API.Controllers
{
    public class TemperatureRequest
    {
        public int MinTempC { get; set; }
        public int MaxTempC { get; set; }
    }


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
        public IEnumerable<WeatherForecast> Get(int resultNum, int minTempC, int maxTempC)
        {
            var result = _weatherForecastService.Get(resultNum, minTempC, maxTempC);
            return result;
        }

        [HttpGet]
        [Route("currentDay")]
        public IActionResult GetCurrentDay()
        {
            var result = _weatherForecastService.GetRandom().First();
            //return StatusCode(400, result);
            return BadRequest(result);
        }

        [HttpPost]
        public string Hello([FromBody] string name)
        {
            return $"Hello {name}";
        }

        [HttpPost("generate")]
        public IActionResult Generate([FromQuery]  int resultNum, [FromBody] TemperatureRequest request)
        {
            if (resultNum < 0 || request.MinTempC > request.MaxTempC)
            {
                return BadRequest("Check your input and try again.");
            }

            var result = _weatherForecastService.Generate(resultNum, request);

            return Ok(result);
        }
    }
}
