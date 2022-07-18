using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreTour.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;


        private static List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            if (weatherForecasts.Count == 0)
            {
                var rng = new Random();
                weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToList();
            }
        }

        [HttpGet]
        public List<WeatherForecast> Get()
        {
            return weatherForecasts;
        }
    }
}
