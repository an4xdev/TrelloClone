namespace Trello.Shared.Requests;

public class ChangeProjectRequest
{
    public int ID { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int TemplateID { get; set; }

}
