namespace Trello.Shared.Requests;

public class AddTemplateRequest
{
    public string Name { get; set; } = string.Empty;

    public List<AddTemplateColumn> Columns { get; set; } = [];
}
