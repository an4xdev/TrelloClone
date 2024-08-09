using System.ComponentModel.DataAnnotations;

namespace Trello.Api.Models;

public class User
{
    [Key]
    public Guid ID { get; set; }

    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string ProfilePicture { get; set; } = string.Empty;

    public bool Notifications { get; set; }
}
