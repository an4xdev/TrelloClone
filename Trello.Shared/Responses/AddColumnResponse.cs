namespace Trello.Shared.Responses;

public class AddColumnResponse : DefaultResponse
{
    public int AddedID { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool MarkAsDone { get; set; } = false;
}
