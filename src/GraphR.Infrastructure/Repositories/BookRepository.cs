using Bindicate.Attributes;
using GrapR.Domain.Exceptions;
using GrapR.Domain.Interfaces;
using GrapR.Domain.Models;
using GrapR.Infrastructure.Database;
using Dapper;

namespace GrapR.Infrastructure.Repositories;

[AddTransient(typeof(IBookRepository))]
public class BookRepository : IBookRepository
{
    private readonly IDbConnectionProvider _dbConnectionProvider;

    public BookRepository(IDbConnectionProvider dbConnectionProvider)
    {
        _dbConnectionProvider = dbConnectionProvider;
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        var query =
            """
            SELECT Id, Title, Description, CategoryId, AuthorID
              FROM dbo.Book
             WHERE Id = @Id
            """;

        var parameters = new DynamicParameters();
        parameters.Add("Id", id);

        using (var connection = _dbConnectionProvider.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<Book>(
                sql: query,
                param: parameters)
            ?? throw new BookNotFoundException(id);
        }
    }
}
