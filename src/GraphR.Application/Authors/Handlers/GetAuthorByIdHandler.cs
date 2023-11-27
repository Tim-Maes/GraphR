using FluentValidation;
using GraphR.Application.Authors.Types.Input;
using GraphR.Application.Authors.Types.Mappings;
using GraphR.Application.Authors.Types.Output;
using GraphR.Domain.Interfaces;
using GrapR.Core.Handlers;

namespace GraphR.Application.Authors.Handlers;

internal sealed class GetAuthorByIdHandler : Handler<AuthorParameters, AuthorDto>, IGetAuthorByIdHandler
{
    private readonly IAuthorRepository _authorRepository;

    public GetAuthorByIdHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    protected override void DefineRules()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }

    protected override async Task<AuthorDto> HandleValidatedRequest(AuthorParameters input)
        => (await _authorRepository.GetById(id: input.Id)).ToOutput();
}

public interface IGetAuthorByIdHandler: IHandler<AuthorParameters, AuthorDto>
{
}
