using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trello.Api.Database;
using Trello.Shared.Requests;
using Trello.Shared.Responses;

namespace Trello.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController(AppDbContext context) : ControllerBase
    {
        [HttpPost("edit")]
        public async Task<DefaultResponse> ChangeItem(ChangeItemRequest request)
        {
            var response = new DefaultResponse();

            var item = await context.Items.Where(i => i.ID == request.Id).FirstOrDefaultAsync();

            if (item == null)
            {
                response.IsSuccess = false;
                response.Message = "The task was not found in the system.";

                return await Task.FromResult(response);
            }

            item.Name = request.Name;
            item.Description = request.Description;

            int changed = await context.SaveChangesAsync();

            if (changed == 0)
            {
                response.IsSuccess = false;
                response.Message = "An error occurred during the task change.";
                return await Task.FromResult(response);
            }

            response.IsSuccess = true;
            response.Message = "The task was successfully changed.";

            return await Task.FromResult(response);

        }
    }
}
