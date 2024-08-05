namespace Trello.Api.Models;

public class Tag
{
    public int ID { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required string BackgroundColor { get; set; } = string.Empty;
    public required string FontColor { get; set; } = string.Empty;
    public ICollection<ItemTag> Items { get; } = [];

}

