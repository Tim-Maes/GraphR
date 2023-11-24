namespace GrapR.Core.Handlers;

public interface IHandler<TResult>
{
    Task<TResult> Handle();
}

public interface IHandler<IRequest, TResult>
{
    Task<TResult> Handle(IRequest request);
}
