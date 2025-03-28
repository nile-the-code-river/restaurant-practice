namespace RestaurantsPractice.API.Controllers
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get(int resultNum, int minTempC, int maxTempC);
        IEnumerable<WeatherForecast> GetRandom();
        IEnumerable<WeatherForecast> Generate(int resultNum, int minTempC, int maxTempC);
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> Get(int resultNum, int minTempC, int maxTempC)
        {
            return Enumerable.Range(1, resultNum).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .Where(x => x.TemperatureC >= minTempC && x.TemperatureC <= maxTempC)
            .ToArray();
        }

        public IEnumerable<WeatherForecast> GetRandom()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public IEnumerable<WeatherForecast> Generate(int resultNum, int minTempC, int maxTempC)
        {
            return Enumerable.Range(1, resultNum).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(minTempC, maxTempC),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
