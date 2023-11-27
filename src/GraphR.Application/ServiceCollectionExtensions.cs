using GrapR.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace GrapR.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddHandlersInAssembly();

        return services;
    }
}
