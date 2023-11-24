using GrapR.Core.Dapper;
using GrapR.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace GrapR.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddDapperFluentMappingsInAssembly();
        services.AddHandlersInAssembly();

        return services;
    }
}
