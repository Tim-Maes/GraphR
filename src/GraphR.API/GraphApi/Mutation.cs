using GraphR.Application.Books.GraphApi;

namespace GraphR.API.GraphApi;

public class Mutation
{
    public BooksMutation Books() => new ();
}
