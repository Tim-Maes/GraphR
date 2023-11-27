using GraphR.Application.Authors.Handlers;
using GraphR.Application.Authors.Types.Input;
using GraphR.Application.Authors.Types.Output;
using HotChocolate;

namespace GraphR.Application.Authors;

public sealed class AuthorsQuery
{
    public async Task<AuthorDto> Author([Service] IGetAuthorByIdHandler handler, AuthorParameters parameters)
        => await handler.Handle(parameters);
}
