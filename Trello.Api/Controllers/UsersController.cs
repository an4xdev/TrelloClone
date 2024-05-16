using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trello.Api.Database;
using Trello.Api.Models;
using Trello.Shared;
namespace Trello.Api.Controllers
{
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
        public async Task<bool> AddUser(AddUser user)
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
    }
}
