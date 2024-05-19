using System.ComponentModel.DataAnnotations;

namespace Trello.Shared
{
    public class Column
    {
        [Key]
        public int ColumnID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

    }
}
