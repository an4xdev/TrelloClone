namespace Trello.Api.Models;

public class Tag
{
    public int ID { get; set; }
    public required string Name { get; set; } = string.Empty;

    public List<ItemTag> ItemTags { get; } = [];

    public int TagColorID { get; set; }

    public TagColor TagColor { get; set; } = null!;
}

