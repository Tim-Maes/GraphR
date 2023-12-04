namespace GraphR.Domain.Interfaces.Transaction;

public interface ITransaction : IDisposable
{
    void Begin();

    void Commit();

    void Rollback();
}
