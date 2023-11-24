using GraphR.Application.Books.GraphApi;

namespace GraphR.API.GraphApi;

public class Query
{
    public BooksQuery Books => new ();
}
