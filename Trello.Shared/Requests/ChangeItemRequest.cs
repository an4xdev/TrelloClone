namespace Trello.Shared.Requests;

public class ChangeItemRequest
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<int> AddedTags { get; set; } = [];

    public List<int> DeletedTags { get; set; } = [];
}
