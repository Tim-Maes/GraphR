using CleanArchitectureTemplate.Core.Dapper;
using CleanArchitectureTemplate.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddDapperFluentMappingsInAssembly();
        services.AddHandlersInAssembly();

        return services;
    }
}
