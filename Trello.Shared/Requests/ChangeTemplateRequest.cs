namespace Trello.Shared.Requests;

public class ChangeTemplateRequest
{
    public int ID { get; set; }

    public string Name { get; set; }

    public List<AddTemplateColumn> AddedColumns { get; set; } = [];

    public List<ChangedColumn> ChangedColumns { get; set; } = [];

    public List<int> DeletedColumnIDs { get; set; } = [];

}

public record ChangedColumn(int ID, string Name);

public record AddTemplateColumn(int ID, string Name);