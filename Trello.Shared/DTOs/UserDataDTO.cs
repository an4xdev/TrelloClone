namespace Trello.Shared.DTOs;

public class UserDataDTO
{
    public string UserName { get; set; } = string.Empty;

    public string ProfilePictureData { get; set; } = string.Empty;

    public string ProfilePictureExtension { get; set; } = string.Empty;

    public bool Notifications { get; set; } = true;
}
