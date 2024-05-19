using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trello.Shared
{
    public class ColumnTemplate
    {

        [Key]
        public int ID { get; set; }

        [ForeignKey("TemplateID")]
        [Required]
        public int TID { get; set; }

        [ForeignKey("ColumnID")]
        [Required]
        public int CID { get; set; }
    }
}
