namespace Trello.Shared.DTOs;

public class ColumnDTO
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;

    public bool MarkAsDone { get; set; }
    public List<ItemDTO> Items { get; set; }
}
