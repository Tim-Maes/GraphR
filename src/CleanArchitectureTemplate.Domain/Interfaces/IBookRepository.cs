using CleanArchitectureTemplate.Domain.Models;

namespace CleanArchitectureTemplate.Domain.Interfaces;

public interface IBookRepository
{
    Task<Book> GetByIdAsync(int id);
}
