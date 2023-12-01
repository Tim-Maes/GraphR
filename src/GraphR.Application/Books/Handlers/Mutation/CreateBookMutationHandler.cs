using FluentValidation;
using GraphR.Application.Books.Types.Input;
using GraphR.Domain.Enums;
using GrapR.Core.Handlers;
using GrapR.Domain.Interfaces;

namespace GraphR.Application.Books.Handlers.Mutation;

internal class CreateBookMutationHandler : Handler<CreateBookParameters, int>,
    ICreateBookMutationHandler
{
    private readonly IBookRepository _repository;

    public CreateBookMutationHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    protected override void DefineRules()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.AuthorId).GreaterThan(0);
    }

    protected override async Task<int> HandleValidatedRequest(CreateBookParameters input)
    {
        await _repository.Create(
            title: input.Title,
            description: input.Description,
            category: Category.Educational,
            authorId: input.AuthorId);

        return 1;
    }
}

public interface ICreateBookMutationHandler : IHandler<CreateBookParameters, int> { }
