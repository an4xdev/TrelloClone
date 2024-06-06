namespace Trello.Api.Models
{
    public class Item
    {
        public int ID { get; set; }

        public required string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int ProjectID { get; set; }
        public Project Project { get; set; } = null!;

        public int ColumnID { get; set; }
        public Column Column { get; set; } = null!;
    }
}
