using DbUp;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace GrapR.Infrastructure.Database.Seed;

public class DbUpgraderBackgroundService : BackgroundService
{
    readonly string _connectionString;

    public DbUpgraderBackgroundService(IOptions<PersistanceOptions> options) =>
        _connectionString = options.Value.ConnectionString;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
#if DEBUG
        EnsureDatabase.For.SqlDatabase(_connectionString);

        var result = DeployChanges.To
            .SqlDatabase(_connectionString)
            .WithScriptsEmbeddedInAssembly(GetType().Assembly)
            .LogToConsole()
            .Build().PerformUpgrade();

        if (!result.Successful)
            throw result.Error;
#endif

        return Task.CompletedTask;
    }
}
