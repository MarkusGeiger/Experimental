using System.Collections.Generic;
using System.Threading.Tasks;
using Experimental.ApiRouting.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Experimental.ApiRouting.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class GhibliMovieController : ControllerBase
  {
    private readonly ILogger<GhibliMovieController> _logger;
    private readonly MovieModel _model;

    public GhibliMovieController(ILogger<GhibliMovieController> logger, MovieModel movieModel)
    {
      _logger = logger;
      _model = movieModel;
    }

    [HttpGet]
    public async Task<IEnumerable<Movie>> Get()
    {
      _logger.LogWarning("Get request received!");

      return await _model.GetMoviesFromExternalSource();
    }
  }
}
