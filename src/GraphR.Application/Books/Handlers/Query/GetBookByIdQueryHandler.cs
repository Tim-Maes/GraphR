using GrapR.Core.Handlers;
using FluentValidation;
using GraphR.Application.Books.Types.Input;
using GraphR.Application.Books.Types.Output;
using GraphR.Application.Books.Types.Mappings;
using GraphR.Domain.Interfaces.Repositories;

namespace GraphR.Application.Books.Handlers.Query;

internal sealed class GetBookByIdQueryHandler : Handler<GetBookByIdParameters, BookDto>, IGetBookByIdHandler
{
    private readonly IBookRepository _bookRepository;

    public GetBookByIdQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    protected override void DefineRules()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }

    protected override async Task<BookDto> HandleValidatedRequest(GetBookByIdParameters request)
        => (await _bookRepository.GetById(request.Id)).ToOutput();
}

public interface IGetBookByIdHandler : IHandler<GetBookByIdParameters, BookDto>
{
}
