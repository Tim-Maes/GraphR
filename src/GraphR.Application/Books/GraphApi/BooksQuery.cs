using GraphR.Application.Books.GraphApi.Handlers.Query;
using GraphR.Application.Books.GraphApi.Types.Input;
using GraphR.Application.Books.GraphApi.Types.Output;
using HotChocolate;

namespace GraphR.Application.Books.GraphApi;

public sealed class BooksQuery
{
    public async Task<BookDto> Book([Service] IGetBookByIdHandler handler, GetBookByIdParameters parameters)
        => await handler.Handle(parameters);
}
