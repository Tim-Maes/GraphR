using GraphR.Application.Authors.Types.Output;
using GraphR.Domain.Entities;

namespace GraphR.Application.Authors.Types.Mappings;

internal static class AuthorMapping
{
    internal static AuthorDto[] ToOutput(this Author[] authors)
        => authors.Select(ToOutput).ToArray();

    internal static AuthorDto ToOutput(this Author author)
        => new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            Biography = author.Biography,
        };
}
