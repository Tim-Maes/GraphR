using FluentValidation;
using GraphR.Application.Books.Types.Input;
using GraphR.Application.Books.Types.Mappings;
using GraphR.Application.Books.Types.Output;
using GraphR.Domain.Interfaces.Repositories;
using GrapR.Core.Handlers;

namespace GraphR.Application.Books.Handlers.Query;
internal sealed class GetBooksForAuthorQueryHandler
    : Handler<GetBooksForAuthorParameters, BookDto[]>, IGetBooksForAuthorQueryHandler
{
    private readonly IBookRepository _bookRepository;

    public GetBooksForAuthorQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    protected override void DefineRules()
    {
        RuleFor(x => x.AuthorId).GreaterThan(0);
    }

    protected override async Task<BookDto[]> HandleValidatedRequest(GetBooksForAuthorParameters request)
        => (await _bookRepository.GetByAuthorId(request.AuthorId)).ToOutput();
}

public interface IGetBooksForAuthorQueryHandler : IHandler<GetBooksForAuthorParameters, BookDto[]> { }
