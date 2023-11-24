using System.Reflection;
using Bindicate.Configuration;
using CleanArchitectureTemplate.Infrastructure.Database.Seed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutowiringForAssembly(Assembly.GetExecutingAssembly())
            .WithOptions(configuration)
            .Register();

        services.AddHostedService<DbUpgraderBackgroundService>();

        return services;
    }
}
