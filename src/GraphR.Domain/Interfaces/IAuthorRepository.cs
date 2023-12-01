using GraphR.Domain.Entities;

namespace GraphR.Domain.Interfaces;
public interface IAuthorRepository
{
    Task<Author> GetById(int id);

    Task<Author[]> GetAll();
}
