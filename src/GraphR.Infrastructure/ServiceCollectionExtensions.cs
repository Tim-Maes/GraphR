using System.Reflection;
using Bindicate;
using GrapR.Core.Dapper;
using GrapR.Infrastructure.Database.Seed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GrapR.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutowiringForAssembly(Assembly.GetExecutingAssembly())
            .WithOptions(configuration)
            .Register();

        services.AddDapperFluentMappingsInAssembly();

        services.AddHostedService<DbUpgraderBackgroundService>();

        return services;
    }
}
