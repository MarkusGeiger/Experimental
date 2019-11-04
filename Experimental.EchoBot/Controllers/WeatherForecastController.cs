using System;
using System.Collections.Generic;
using System.Linq;
using Experimental.EchoBot.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Experimental.EchoBot.Controllers
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
    private readonly BotService _bot;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, BotService bot)
    {
      _logger = logger;
      _bot = bot;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
      throw new InvalidOperationException($"This operation with id '{id}' is not valid, because a exception is always thrown when calling it.");
    }
  }
}
