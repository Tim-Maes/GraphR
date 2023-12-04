using GraphR.Domain.Entities;

namespace GraphR.Domain.Interfaces.Repositories;
public interface IAuthorRepository
{
    Task<Author> GetById(int id);

    Task<Author[]> GetAll();
}
