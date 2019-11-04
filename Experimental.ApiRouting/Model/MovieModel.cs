using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Experimental.ApiRouting.Model
{
  public class MovieModel
  {
    private static ILogger<MovieModel> _logger;

    public MovieModel(ILogger<MovieModel> logger)
    {
      _logger = logger;
      _logger.LogWarning("MovieModel instance created!");
    }

    public IEnumerable<Movie> Movies => _movies;
    private List<Movie> _movies;

    public async Task<IEnumerable<Movie>> GetMoviesFromExternalSource()
    {
      if (_movies != null && _movies.Any())
      {
        _logger.LogWarning("Returning stored movies for this request.");
        return _movies;
      }

      _logger.LogWarning("Newly fetching movies now.");
      string msg = string.Empty;
      IEnumerable<Movie> movies = null;
      try
      {
        using HttpClient client = new HttpClient();
        var stringTask = client.GetStringAsync("https://ghibliapi.herokuapp.com/films");
        msg = await stringTask;

        if (!string.IsNullOrWhiteSpace(msg))
        {
          movies = JsonSerializer.Deserialize<List<Movie>>(msg);
        }
      }
      catch (HttpRequestException exception)
      {
        Console.WriteLine("Error!" + Environment.NewLine + exception);
      }

      if (movies != null && movies.Any())
      {
        _logger.LogWarning("MovieModel filled with data from ghibliapp!");
        _movies = new List<Movie>(movies);
      }

      return movies;
    }
  }
}
