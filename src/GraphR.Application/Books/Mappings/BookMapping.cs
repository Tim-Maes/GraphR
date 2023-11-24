using GraphR.Application.Books.GraphApi.Types.Output;
using GrapR.Domain.Models;

namespace GraphR.Application.Books.Mappings;

internal static class BookMapping
{
    internal static BookDto ToOutput(this Book book)
        => new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            Category = book.Category.ToString(),
        };
}
