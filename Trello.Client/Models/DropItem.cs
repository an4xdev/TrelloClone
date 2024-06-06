using Trello.Shared.DTOs;

namespace Trello.Client.Models
{
    public class DropItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Group { get; set; }

        public string Description { get; set; }

        public DropItem(DropItem dropItem)
        {
            Id = dropItem.Id;
            Name = dropItem.Name;
            Group = dropItem.Group;
            Description = dropItem.Description;
        }

        public DropItem(ColumnDTO column, ItemDTO item)
        {
            Id = item.ID;
            Name = item.Name;
            Description = item.Description;
            Group = column.Name;
        }
    }
}
