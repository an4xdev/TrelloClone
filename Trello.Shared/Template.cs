using System.ComponentModel.DataAnnotations;

namespace Trello.Shared
{
    public class Template
    {
        [Key]
        public int TemplateID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
