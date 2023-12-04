using System.Data;
using Bindicate.Attributes;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace GrapR.Infrastructure.Database;

[AddTransient(typeof(IDbConnectionProvider))]
public class DbConnectionProvider : IDbConnectionProvider
{
    private readonly IOptions<InfrastructureOptions> _options;

    public DbConnectionProvider(IOptions<InfrastructureOptions> options)
    {
        _options = options;
    }

    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_options.Value.ConnectionString);
        connection.Open();
        return connection;
    }

    public string Schema { get; }
}

public interface IDbConnectionProvider
{
    IDbConnection CreateConnection();
    string Schema { get; }
}
