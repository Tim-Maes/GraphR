using GrapR.Domain.Enums;
using GrapR.Domain.Models;

namespace GrapR.Domain.Interfaces;

public interface IBookRepository
{
    Task<Book> GetById(int id);

    Task Create(string title, string description, Category category, int authorId);
}
