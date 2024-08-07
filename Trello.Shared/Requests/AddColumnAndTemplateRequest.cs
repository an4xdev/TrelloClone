namespace Trello.Shared.Requests;

public class AddColumnAndTemplateRequest
{
    public int ProjectID { get; set; }

    public string ColumnName { get; set; } = string.Empty;
    public int TemplateID { get; set; }
    public string TemplateName { get; set; } = string.Empty;

    public bool MarkAsDone { get; set; } = false;

}
