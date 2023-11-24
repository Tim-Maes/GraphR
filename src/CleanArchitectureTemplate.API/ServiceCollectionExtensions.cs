using CleanArchitectureTemplate.Application;
using CleanArchitectureTemplate.Core;
using CleanArchitectureTemplate.Infrastructure;

namespace CleanArchitectureTemplate.WebAPI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSolutionComponents(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication();
        services.AddCore();
        services.AddInfrastructure(configuration);

        return services;
    }
}
