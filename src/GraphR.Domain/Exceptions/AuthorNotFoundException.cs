namespace GraphR.Domain.Exceptions;

public sealed class AuthorNotFoundException : Exception
{
    public AuthorNotFoundException(int id)
        : base($"Author with id {id} not found.")
    {
        Id = id;
    }

    public int Id { get; }
}
