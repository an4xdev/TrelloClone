namespace Trello.Api.Models;

public class ItemTag
{
    public int ID { get; set; }
    public int ItemID { get; set; }
    public int TagID { get; set; }
    public Item Item { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}
