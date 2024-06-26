using GraphR.Application.Books.Types.Output;
using GraphR.Domain.Entities;

namespace GraphR.Application.Books.Types.Mappings;

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

    internal static BookDto[] ToOutput(this Book[] books)
        => books.Select(ToOutput).ToArray();
}
