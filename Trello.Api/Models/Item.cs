namespace Trello.Api.Models;

public class Item
{
    public int ID { get; set; }

    public required string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateOnly? DoneDate { get; set; }

    public int ProjectID { get; set; }
    public Project Project { get; set; } = null!;

    public int ColumnID { get; set; }
    public Column Column { get; set; } = null!;

    public List<ItemTag> ItemTags { get; } = [];
}
