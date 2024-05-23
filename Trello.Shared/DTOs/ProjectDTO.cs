namespace Trello.Shared.DTOs
{
    public class ProjectDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TemplateDTO Template { get; set; }
        public ICollection<ItemDTO> Items { get; set; }
    }
}
