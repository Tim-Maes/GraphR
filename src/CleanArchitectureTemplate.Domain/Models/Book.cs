using CleanArchitectureTemplate.Domain.Enums;

namespace CleanArchitectureTemplate.Domain.Models;

public sealed class Book
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Category Category { get; set; }
}
