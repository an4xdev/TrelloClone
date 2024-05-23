namespace Trello.Shared.DTOs
{
    public class TemplateDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<ColumnDTO> Columns { get; set; }
    }
}
