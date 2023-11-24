using Microsoft.Extensions.DependencyInjection;

namespace GrapR.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
}
