namespace Trello.Shared.DTOs
{
    public class ColumnDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<ItemDTO> Items { get; set; }
    }
}
