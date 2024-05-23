namespace Trello.Shared.Models
{
    public class Template
    {
        public int ID { get; set; }
        public required string Name { get; set; } = string.Empty;

        public ICollection<Column> Columns { get; set; } = [];
    }
}
