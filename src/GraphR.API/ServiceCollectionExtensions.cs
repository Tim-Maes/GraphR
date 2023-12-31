using GrapR.Application;
using GrapR.Infrastructure;

namespace GrapR.WebAPI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSolutionComponents(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication();
        services.AddInfrastructure(configuration);

        return services;
    }
}
