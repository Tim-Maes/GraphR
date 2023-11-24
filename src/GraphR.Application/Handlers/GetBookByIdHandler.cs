using GrapR.Application.Dto;
using GrapR.Application.Dto.Mappings;
using GrapR.Application.Requests;
using GrapR.Core.Handlers;
using GrapR.Domain.Interfaces;
using FluentValidation;

namespace GrapR.Application.Handlers;

internal sealed class GetBookByIdHandler : Handler<GetBookByIdRequest, BookDto>, IGetBookByIdHandler
{
    private readonly IBookRepository _bookRepository;

    public GetBookByIdHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    protected override void DefineRules()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }

    protected override async Task<BookDto> HandleValidatedRequest(GetBookByIdRequest request)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);

        return book.ToDto();
    }
}

public interface IGetBookByIdHandler: IHandler<GetBookByIdRequest, BookDto>
{
}
