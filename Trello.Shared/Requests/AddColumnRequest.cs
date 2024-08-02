namespace Trello.Shared.Requests;

public class AddColumnRequest
{
    public int TemplateID { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool MarkAsDone { get; set; } = false;
}
