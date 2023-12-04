using GraphR.Application.Books.Handlers.Mutation;
using GraphR.Application.Books.Types.Input;
using HotChocolate;

namespace GraphR.Application.Books;

public sealed class BooksMutation
{
    public async Task<int> CreateBook([Service] ICreateBookMutationHandler handler, CreateBookParameters parameters)
        => await handler.Handle(parameters);
}
