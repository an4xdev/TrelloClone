namespace Trello.Shared.DTOs;

public class OnlyProjectDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int TemplateID { get; set; }
}
