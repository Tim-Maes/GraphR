using System.Data;
using Bindicate.Attributes;
using GraphR.Domain.Interfaces.Transaction;
using GrapR.Infrastructure.Database;

namespace GraphR.Infrastructure.Database;

[AddTransient(typeof(ITransaction))]
public class DbTransaction : ITransaction
{
    private readonly IDbConnectionProvider _connectionProvider;
    private IDbConnection _connection;
    private IDbTransaction _transaction;
    private bool _disposed;

    public DbTransaction(IDbConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public void Begin()
    {
        if (_connection is null) _connection = _connectionProvider.CreateConnection();

        if (_connection.State is not ConnectionState.Open) _connection.Open();

        _transaction = _connection.BeginTransaction();
    }

    public void Commit()
    {
        try
        {
            _transaction?.Commit();
        }
        catch
        {
            Rollback();
            throw;
        }
        finally
        {
            DisposeTransaction();
        }
    }

    public void Rollback()
    {
        _transaction?.Rollback();
        DisposeTransaction();
    }

    private void DisposeTransaction()
    {
        _transaction?.Dispose();
        _transaction = null;
    }

    public void Dispose()
    {
        if (_disposed)
            return;

        _disposed = true;
        DisposeTransaction();

        if (_connection is null)
        {
            _connection.Dispose();
            _connection = null;
        }
    }
}
