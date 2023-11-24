using GrapR.Domain.Models;
using Dapper.FluentMap.Mapping;

namespace GrapR.Application.Maps;

internal class BookMap : EntityMap<Book>
{
    public BookMap()
    {
        Map(x => x.Id).ToColumn("Id");
        Map(x => x.Title).ToColumn("Title");
        Map(x => x.Description).ToColumn("Description");
        Map(x => x.Category).ToColumn("Category");
    }
}
