using GrapR.Application.Dto;
using GrapR.Application.Handlers;

namespace GrapR.API.GraphApi.Query;

public class Query
{
    public async Task<BookDto> GetBook([Service] IGetBookByIdHandler handler, int id)
        => await handler.Handle(new() { Id = id });
}
