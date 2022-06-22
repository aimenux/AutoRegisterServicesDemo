using Microsoft.Extensions.Logging;

namespace ScrutorConsoleApp;

public class DummyServiceTwo : IDummyService
{
    private readonly ILogger<DummyServiceOne> _logger;

    public DummyServiceTwo(ILogger<DummyServiceOne> logger)
    {
        _logger = logger;
    }

    public Task RunAsync()
    {
        _logger.LogInformation($"Random int64: {Random.Shared.NextInt64()}");
        _logger.LogInformation($"Random double: {Random.Shared.NextDouble()}");
        return Task.Delay(Settings.Delay);
    }
}