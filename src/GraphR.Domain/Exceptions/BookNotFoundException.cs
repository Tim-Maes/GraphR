namespace GrapR.Domain.Exceptions;

public sealed class BookNotFoundException : Exception
{
    public BookNotFoundException(int id)
        : base($"Book with id {id} not found.")
    {
        Id = id;
    }

    public int Id { get; }
}
