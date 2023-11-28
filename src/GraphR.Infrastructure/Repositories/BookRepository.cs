using Bindicate.Attributes;
using GrapR.Domain.Exceptions;
using GrapR.Domain.Interfaces;
using GrapR.Domain.Models;
using GrapR.Infrastructure.Database;
using Dapper;
using GrapR.Domain.Enums;

namespace GrapR.Infrastructure.Repositories;

[AddTransient(typeof(IBookRepository))]
public class BookRepository : IBookRepository
{
    private readonly IDbConnectionProvider _dbConnectionProvider;

    public BookRepository(IDbConnectionProvider dbConnectionProvider)
    {
        _dbConnectionProvider = dbConnectionProvider;
    }

    public async Task<Book> GetById(int id)
    {
        var query =
            """
            SELECT Id, Title, Description, CategoryId, AuthorId
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

    public async Task<Book[]> GetByAuthorId(int authorId)
    {
        var query =
            """
            SELECT Id, Title, Description, CategoryId, AuthorId
              FROM dbo.Book
             WHERE AuthorID = @AuthorId
            """;

        var parameters = new DynamicParameters();
        parameters.Add("AuthorId", authorId);

        using (var connection = _dbConnectionProvider.CreateConnection())
        {
            return (await connection.QueryAsync<Book>(
                sql: query,
                param: parameters)).ToArray();
        }

    }

    public async Task Create(string title, string description, Category category, int authorId)
    {
        var query =
            """
            INSERT INTO dbo.book
                       (Title, Description, CategoryId, AuthorId)
                 VALUES
                       (@Title, @Description, @CategoryId, @AuthorId)
            """;

        var parameters = new DynamicParameters();
        parameters.Add("Title", title);
        parameters.Add("Description", description);
        parameters.Add("CategoryId", (int)category);
        parameters.Add("AuthorId", authorId);

        using (var connection = _dbConnectionProvider.CreateConnection())
        {
            await connection.ExecuteAsync(
                sql: query,
                param: parameters);
        }
    }
}
