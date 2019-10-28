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

    public GhibliMovieController(ILogger<GhibliMovieController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<Movie>> Get()
    {
      _logger.LogWarning("Get request received!");

      return await MovieModel.Instance().GetMoviesFromExternalSource();
    }
  }
}
