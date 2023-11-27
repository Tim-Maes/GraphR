using GraphR.Application.Authors.Types.Output;
using GrapR.Domain.Models;

namespace GraphR.Application.Authors.Types.Mappings;

internal static class AuthorMapping
{
    internal static AuthorDto ToOutput(this Author author)
        => new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
        };
}
