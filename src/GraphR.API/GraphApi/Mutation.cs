using GraphR.Application.Books;

namespace GraphR.API.GraphApi;

public class Mutation
{
    public BooksMutation Books() => new ();
}
