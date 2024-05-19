using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trello.Shared
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [ForeignKey("TemplateID")]
        public int TID { get; set; }
    }
}
