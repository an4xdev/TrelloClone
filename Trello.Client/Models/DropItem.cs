using Trello.Shared.DTOs;

namespace Trello.Client.Models
{
    public class DropItem
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Group { get; set; }

        public string Description { get; set; }

        public DropItem(int id, string name, string group, string description)
        {
            ID = id;
            Name = name;
            Group = group;
            Description = description;
        }

        public DropItem(DropItem dropItem)
        {
            ID = dropItem.ID;
            Name = dropItem.Name;
            Group = dropItem.Group;
            Description = dropItem.Description;
        }

        public DropItem(ColumnDTO column, ItemDTO item)
        {
            ID = item.ID;
            Name = item.Name;
            Description = item.Description;
            Group = column.Name;
        }
    }
}
