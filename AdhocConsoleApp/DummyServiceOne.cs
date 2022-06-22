using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AdhocConsoleApp;

public class DummyServiceOne : IDummyService
{
    private readonly IOptions<Settings> _options;
    private readonly ILogger<DummyServiceOne> _logger;

    public DummyServiceOne(IOptions<Settings> options, ILogger<DummyServiceOne> logger)
    {
        _options = options;
        _logger = logger;
    }

    public Task RunAsync()
    {
        _logger.LogInformation($"{nameof(Settings.Username)}: {_options.Value.Username}");
        _logger.LogInformation($"{nameof(Settings.Password)}: {_options.Value.Password}");
        return Task.Delay(Settings.Delay);
    }
}