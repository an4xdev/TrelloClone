using Trello.Shared.DTOs;

namespace Trello.Client.Models
{
    public class DropItem
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Group { get; set; }

        public string Description { get; set; }

        public DateOnly? DoneDate { get; set; }

        public List<TagDTO> Tags { get; set; }

        public DropItem(int id, string name, string group, string description, DateOnly? doneDate, List<TagDTO> tags)
        {
            ID = id;
            Name = name;
            Group = group;
            Description = description;
            DoneDate = doneDate;
            Tags = tags;
        }

        public DropItem(DropItem dropItem)
        {
            ID = dropItem.ID;
            Name = dropItem.Name;
            Group = dropItem.Group;
            Description = dropItem.Description;
            DoneDate = dropItem.DoneDate;
            Tags = dropItem.Tags;
        }

        public DropItem(ColumnDTO column, ItemDTO item)
        {
            ID = item.ID;
            Name = item.Name;
            Description = item.Description;
            Group = column.Name;
            DoneDate = item.DoneDate;
            Tags = item.Tags;
        }
    }
}
