using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trello.Api.Database;
using Trello.Api.Models;
using Trello.Shared.DTOs;
namespace Trello.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<bool> IsUserInDatabase()
    {
        var isIn = await context.Users.AnyAsync();
        return await Task.FromResult(isIn);
    }

    [HttpPost]
    public async Task<bool> AddUser(UserDataDTO user)
    {

        Console.WriteLine(user.UserName);

        Guid guid = Guid.NewGuid();
        string targetFileName = $"{guid}.{user.ProfilePictureExtension}";
        string targetFilePath = Path.Combine("Uploads", targetFileName);

        byte[] data = Convert.FromBase64String(user.ProfilePictureData);
        await context.Users.AddAsync(new User()
        {
            ID = guid,
            UserName = user.UserName,
            ProfilePicture = targetFilePath
        });

        bool result = await context.SaveChangesAsync() == 1;
        try
        {
            FileStream stream = new(targetFilePath, FileMode.Create, FileAccess.Write);
            stream.Write(data, 0, data.Length);
            stream.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            result = false;
        }

        return await Task.FromResult(result);
    }

    [HttpGet("user")]
    public async Task<UserDataDTO> GetUserData()
    {

        var user = await context.Users.FirstOrDefaultAsync();

        UserDataDTO response = new()
        {
            UserName = string.Empty,
            ProfilePictureData = string.Empty,
            ProfilePictureExtension = string.Empty,
        };
        if (user != null)
        {

            byte[] photoData = System.IO.File.ReadAllBytes(user.ProfilePicture);
            string photo = Convert.ToBase64String(photoData);
            string ext = Path.GetExtension(user.ProfilePicture).Split(".")[1];
            response.ProfilePictureData = photo;
            response.ProfilePictureExtension = ext;
            response.UserName = user.UserName;


        }

        return await Task.FromResult(response);

    }
}
