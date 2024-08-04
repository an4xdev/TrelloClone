namespace Trello.Api.Models;

public class ItemTag
{
    public int ID { get; set; }
    public int ItemId { get; set; }
    public int TagsId { get; set; }
    public Item Item { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}
