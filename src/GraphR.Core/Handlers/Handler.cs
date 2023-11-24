using FluentValidation;

namespace GrapR.Core.Handlers;

public abstract class Handler<TOutput>
        : IHandler<TOutput>
{
    public abstract Task<TOutput> Handle();
}

public abstract class Handler<TInput, TOutput>
    : AbstractValidator<TInput>, IHandler<TInput, TOutput>
{
    public async Task<TOutput> Handle(TInput input)
    {
        DefineRules();
        this.ValidateAndThrow(input);
        return await HandleValidatedRequest(input);
    }

    protected abstract void DefineRules();

    protected abstract Task<TOutput> HandleValidatedRequest(TInput input);
}
