namespace Trello.Shared.DTOs;

public class ItemDTO
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public DateOnly? DoneDate { get; set; }

    public List<TagDTO> Tags { get; set; }
}
