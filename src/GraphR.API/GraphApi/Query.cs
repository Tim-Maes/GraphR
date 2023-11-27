using GraphR.Application.Authors;
using GraphR.Application.Books;

namespace GraphR.API.GraphApi;

public class Query
{
    public AuthorsQuery Authors => new();

    public BooksQuery Books => new();
}
