using FluentValidation;

namespace CleanArchitectureTemplate.Core.Handlers;

public abstract class QueryHandler<TOutput>
        : IHandler<TOutput>
{
    public abstract Task<TOutput> Handle();
}

public abstract class Handler<TRequest, TOutput>
    : AbstractValidator<TRequest>, IHandler<TRequest, TOutput>
{
    public async Task<TOutput> Handle(TRequest request)
    {
        DefineRules();
        this.ValidateAndThrow(request);
        return await HandleValidatedRequest(request);
    }

    protected abstract void DefineRules();

    protected abstract Task<TOutput> HandleValidatedRequest(TRequest input);
}
