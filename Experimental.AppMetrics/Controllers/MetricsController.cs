using System.Threading.Tasks;
using Experimental.AppMetrics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Experimental.AppMetrics.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MetricsController : ControllerBase
  {
    private readonly ILogger<MetricsController> _logger;
    private readonly Metrics _metrics;

    public MetricsController(ILogger<MetricsController> logger, Metrics metricsService)
    {
      _logger = logger;
      _metrics = metricsService;
    }

    [HttpGet("increment")]
    public IActionResult GetIncrement()
    {
      _metrics.IncrementCounter();
      return Ok();
    }

    [HttpGet("snapshot")]
    public async Task<IActionResult> GetSnapshot()
    {
      await _metrics.GetSnapshotAsync();
      return Ok();
    }
  }
}