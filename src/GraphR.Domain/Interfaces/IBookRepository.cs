using GraphR.Domain.Entities;
using GraphR.Domain.Enums;

namespace GrapR.Domain.Interfaces;

public interface IBookRepository
{
    Task<Book> GetById(int id);

    Task<Book[]> GetByAuthorId(int authorId);

    Task Create(string title, string description, Category category, int authorId);
}
