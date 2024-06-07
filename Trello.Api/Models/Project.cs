namespace Trello.Api.Models
{
    public class Project
    {
        public int ID { get; set; }

        public required string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public int TemplateID { get; set; }
        public Template Template { get; set; } = null!;

        public ICollection<Item> Items { get; set; } = [];
    }
}
