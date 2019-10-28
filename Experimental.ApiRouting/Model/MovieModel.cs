using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Experimental.ApiRouting.Model
{
  public class MovieModel
  {
    #region singleton
    private static MovieModel _instance;
    private static ILogger<MovieModel> _logger;
    public static MovieModel Instance(ILogger<MovieModel> logger)
    {
      _logger = logger;
      _logger.LogWarning("MovieModel instance created!");
      return Instance();
    }

    public static MovieModel Instance()
    {
      return _instance ?? (_instance = new MovieModel()); 
    }
    #endregion

    private MovieModel()
    {
    }

    public IEnumerable<Movie> Movies => _movies;
    private List<Movie> _movies;


    public async Task<IEnumerable<Movie>> GetMoviesFromExternalSource()
    {
      if (_movies != null && _movies.Any()) return _movies;

      string msg = string.Empty;
      IEnumerable<Movie> movies = null;
      try
      {
        using (HttpClient client = new HttpClient())
        {
          //var serializer = new DataContractJsonSerializer(typeof(List<Movie>));
          //var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
          //var repositories = serializer.ReadObject(await streamTask) as List<Movie>;

          //Console.WriteLine("Done!");
          var stringTask = client.GetStringAsync("https://ghibliapi.herokuapp.com/films");
          msg = await stringTask;

          if (!string.IsNullOrWhiteSpace(msg))
          {
            Debug.WriteLine(msg);
            Console.WriteLine(msg);
            _logger?.LogWarning(msg);

            movies = JsonSerializer.Deserialize<List<Movie>>(msg);
          }
        }
      }
      catch (HttpRequestException exception)
      {
        Console.WriteLine("Error!" + Environment.NewLine + exception);
      }
      if (movies != null && movies.Any()) _movies = new List<Movie>(movies);
      return movies;
    }
  }
}
