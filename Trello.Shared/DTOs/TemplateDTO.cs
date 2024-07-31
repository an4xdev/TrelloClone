namespace Trello.Shared.DTOs;

public class TemplateDTO
{
    public int ID { get; set; }
    public string Name { get; set; }
    public List<ColumnDTO> Columns { get; set; }
}
