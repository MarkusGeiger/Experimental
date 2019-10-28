using System;

namespace Experimental.Swagger
{
  /// <summary>
  /// Weather forecast model class
  /// </summary>
  public class WeatherForecast
  {
    /// <summary>
    /// Date of this weather forecast
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Temperature for this weather forecast in degreees celsius
    /// </summary>
    public int TemperatureC { get; set; }

    /// <summary>
    /// Temperature for this weather forecast in degreees fahrenheit
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    /// <summary>
    /// Summary text for this weather forecast
    /// </summary>
    public string Summary { get; set; }
  }
}
