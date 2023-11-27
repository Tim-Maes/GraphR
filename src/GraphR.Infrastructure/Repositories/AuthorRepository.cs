using Bindicate.Attributes;
using Dapper;
using GraphR.Domain.Exceptions;
using GraphR.Domain.Interfaces;
using GrapR.Domain.Models;
using GrapR.Infrastructure.Database;

namespace GrapR.Infrastructure.Repositories;

[AddTransient(typeof(IAuthorRepository))]
public class AuthorRepository : IAuthorRepository
{
    private readonly IDbConnectionProvider _dbConnectionProvider;

    public AuthorRepository(IDbConnectionProvider dbConnectionProvider)
    {
        _dbConnectionProvider = dbConnectionProvider;
    }

    public async Task<Author> GetById(int id)
    {
        var query =
            """
            SELECT Name, Biography
              FROM dbo.Author
             WHERE Id = @Id
            """;

        var parameters = new DynamicParameters();
        parameters.Add("Id", id);

        using (var connection = _dbConnectionProvider.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<Author>(
                sql: query,
                param: parameters)
            ?? throw new AuthorNotFoundException(id);
        }
    }
}
