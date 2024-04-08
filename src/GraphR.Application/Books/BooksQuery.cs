using GraphR.Application.Books.Handlers.Query;
using GraphR.Application.Books.Types.Input;
using GraphR.Application.Books.Types.Output;
using HotChocolate;

namespace GraphR.Application.Books;

public sealed class BooksQuery
{
    public async Task<BookDto> Book([Service] IGetBookByIdHandler handler, GetBookByIdParameters parameters)
        => await handler.Handle(parameters);

    public async Task<BookDto[]> BooksForAuthor([Service] IGetBooksForAuthorQueryHandler handler, GetBooksForAuthorParameters parameters)
    => await handler.Handle(parameters);
}
