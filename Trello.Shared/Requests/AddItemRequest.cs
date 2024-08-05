namespace Trello.Shared.Requests;

public class AddItemRequest
{

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int ProjectID { get; set; }

    public int ColumnID { get; set; }

    public List<int> TagIDs { get; set; }
}
