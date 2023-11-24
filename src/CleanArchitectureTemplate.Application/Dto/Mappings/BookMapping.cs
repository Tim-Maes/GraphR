using CleanArchitectureTemplate.Domain.Models;

namespace CleanArchitectureTemplate.Application.Dto.Mappings;

internal static class BookMapping
{
    internal static BookDto ToDto(this Book book)
        => new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            Category = book.Category.ToString(),
        };
}
