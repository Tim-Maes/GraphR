namespace GraphR.Application.Books.Types.Input;
public sealed class CreateBookParameters
{
    public string Title { get; set; }

    public string Description { get; set; }

    public int AuthorId { get; set; }
}
