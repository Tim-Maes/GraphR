using System.Reflection;
using Dapper.FluentMap;
using Dapper.FluentMap.Configuration;
using Dapper.FluentMap.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.Core.Dapper;
public static class DapperMappingServiceCollectionExtensions
{
    public static IServiceCollection AddDapperFluentMappingsInAssembly(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();

        FluentMapper.Initialize(configuration =>
        {
            IEnumerable<(Type MapType, Type InterfaceType)> mappings = assembly.GetTypes()
                .Select(x => (mapType: x, entityType: x.GetInterface(typeof(IEntityMap<>).Name)?.GetGenericArguments()[0]))
                .Where(x => x.entityType != null);

            foreach ((Type mapType, Type entityType) in mappings)
            {
                MethodInfo addMapMethod = typeof(FluentMapConfiguration).GetMethod(nameof(FluentMapConfiguration.AddMap), BindingFlags.Public | BindingFlags.Instance)
                    .MakeGenericMethod(entityType);
                var map = Activator.CreateInstance(mapType);
                addMapMethod.Invoke(configuration, new object[] { map });
            }
        });

        return services;
    }
}
