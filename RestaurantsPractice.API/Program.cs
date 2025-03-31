using RestaurantsPractice.API.Controllers;
using RestaurantsPractice.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
