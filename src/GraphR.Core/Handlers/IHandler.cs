namespace GrapR.Core.Handlers;

public interface IHandler<TResult>
{
    Task<TResult> Handle();
}

public interface IHandler<TInput, TResult>
{
    Task<TResult> Handle(TInput input);
}
