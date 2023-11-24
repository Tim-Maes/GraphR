using System.Data;
using Bindicate.Attributes;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace GrapR.Infrastructure.Database;

[AddSingleton(typeof(IDbConnectionProvider))]
public class DbConnectionProvider : IDbConnectionProvider
{
    private readonly string _connectionString;

    public DbConnectionProvider(IOptions<PersistanceOptions> options)
    {
        _connectionString = options.Value.ConnectionString;
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}

public interface IDbConnectionProvider
{
    IDbConnection CreateConnection();
}
