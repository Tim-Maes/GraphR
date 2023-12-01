using Dapper.FluentMap.Mapping;
using GraphR.Domain.Entities;

namespace GraphR.Infrastructure.Maps;

internal class AuthorMap : EntityMap<Author>
{
    public AuthorMap()
    {
        Map(x => x.Id).ToColumn("Id");
        Map(x => x.Name).ToColumn("Name");
        Map(x => x.Biography).ToColumn("Biography");
    }
}
