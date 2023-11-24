using CleanArchitectureTemplate.Application.Dto;
using CleanArchitectureTemplate.Application.Handlers;

namespace CleanArchitectureTemplate.API.GraphApi.Query;

public class Query
{
    public async Task<BookDto> GetBook([Service] IGetBookByIdHandler handler, int id)
        => await handler.Handle(new() { Id = id });
}
