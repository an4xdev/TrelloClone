namespace Trello.Api.Models;

public class TagColor
{
    public int ID { get; set; }

    public required string Name { get; set; } = string.Empty;

    public ICollection<Tag> Tags { get; set; } = [];
}
