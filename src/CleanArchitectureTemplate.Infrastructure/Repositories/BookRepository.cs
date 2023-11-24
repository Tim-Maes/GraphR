using Bindicate.Attributes;
using CleanArchitectureTemplate.Domain.Exceptions;
using CleanArchitectureTemplate.Domain.Interfaces;
using CleanArchitectureTemplate.Domain.Models;
using CleanArchitectureTemplate.Infrastructure.Database;
using Dapper;

namespace CleanArchitectureTemplate.Infrastructure.Repositories;

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
