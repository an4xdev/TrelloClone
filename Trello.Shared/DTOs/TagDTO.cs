namespace Trello.Shared.DTOs;

public class TagDTO
{
    public int ID { get; set; }

    public string Name { get; set; } = string.Empty;

    public string BackgroundColor { get; set; } = string.Empty;
    public string FontColor { get; set; } = string.Empty;
}
