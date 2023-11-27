using GrapR.Domain.Models;

namespace GraphR.Domain.Interfaces;
public interface IAuthorRepository
{
    Task<Author> GetById(int id);
}
