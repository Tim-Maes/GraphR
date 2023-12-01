using GraphR.Application.Authors.Types.Mappings;
using GraphR.Application.Authors.Types.Output;
using GraphR.Domain.Interfaces;
using GrapR.Core.Handlers;

namespace GraphR.Application.Authors.Handlers;

internal sealed class GetAuthorsQueryHandler : Handler<AuthorDto[]>, IGetAuthorsQueryHandler
{
    private readonly IAuthorRepository _repository;

    public GetAuthorsQueryHandler(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public override async Task<AuthorDto[]> Handle()
        => (await _repository.GetAll()).ToOutput();
}

public interface IGetAuthorsQueryHandler : IHandler<AuthorDto[]> { }
