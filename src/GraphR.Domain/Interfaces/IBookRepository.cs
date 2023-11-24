using GrapR.Domain.Models;

namespace GrapR.Domain.Interfaces;

public interface IBookRepository
{
    Task<Book> GetByIdAsync(int id);
}
