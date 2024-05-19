using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trello.Shared
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [ForeignKey("ProjectID")]
        public int PID { get; set; }
    }
}
