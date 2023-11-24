using GraphR.Application.Books.GraphApi.Handlers.Mutation;
using GraphR.Application.Books.GraphApi.Types.Input;
using HotChocolate;

namespace GraphR.Application.Books.GraphApi;

public sealed class BooksMutation
{
    public async Task<int> CreateBook([Service] ICreateBookMutationHandler handler, CreateBookParameters request)
        => await handler.Handle(request);
}
