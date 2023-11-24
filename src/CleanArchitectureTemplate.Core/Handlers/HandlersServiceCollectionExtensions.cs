using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.Core.Handlers;

public static class HandlersServiceCollectionExtensions
{
    public static IServiceCollection AddHandlersInAssembly(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();
        foreach (Type implementationType in assembly.GetTypes().Where(IsNonAbstractClass))
        {
            foreach (Type interfaceType in FindInterfaceTypesInAssembly(implementationType))
                services.AddScoped(interfaceType, implementationType);
        }

        return services;
    }

    private static bool IsNonAbstractClass(Type type)
        => type.IsClass && !type.IsAbstract;

    private static IEnumerable<Type> FindInterfaceTypesInAssembly(Type type)
    {
        Type[] interfaceTypes = type.GetInterfaces();
        if (interfaceTypes.Any(IsGenericHandlerInterface))
            return interfaceTypes.Where(x => x.Assembly == type.Assembly);
        return Enumerable.Empty<Type>();
    }

    private static bool IsGenericHandlerInterface(Type x)
        => x.IsGenericType && (x.GetGenericTypeDefinition() == typeof(IHandler<,>) || x.GetGenericTypeDefinition() == typeof(IHandler<>));
}
