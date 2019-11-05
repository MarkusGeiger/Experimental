using App.Metrics;
using App.Metrics.Counter;
using App.Metrics.Scheduling;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Experimental.AppMetrics.Services
{
  public class Metrics
  {
    private readonly ILogger<Metrics> _logger;
    private readonly IMetricsRoot _metrics;
    private readonly CounterOptions _counter;

    public Metrics(ILogger<Metrics> logger)
    {
      _logger = logger;
      _metrics = new MetricsBuilder()
        .Report.ToConsole()
        .Build();
      _counter = new CounterOptions { Name = "my_counter" };
      _logger.LogDebug("Metrics built!");
      var scheduler = new AppMetricsTaskScheduler(
        TimeSpan.FromSeconds(3),
        async () =>
        {
          await Task.WhenAll(_metrics.ReportRunner.RunAllAsync());
        });
      scheduler.Start();
    }

    public void IncrementCounter()
    {
      _metrics.Measure.Counter.Increment(_counter);
    }

    public async Task GetSnapshotAsync()
    {
      var snapshot = _metrics.Snapshot.Get();
      using (var stream = new MemoryStream())
      {
        await _metrics.DefaultOutputMetricsFormatter.WriteAsync(stream, snapshot);
        await _metrics.DefaultOutputEnvFormatter.WriteAsync(stream, _metrics.EnvironmentInfo);

        var result = Encoding.UTF8.GetString(stream.ToArray());
        _logger.LogInformation(result);
      }
    }
  }
}
