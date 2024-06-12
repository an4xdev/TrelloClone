using Microsoft.AspNetCore.Mvc;
using Trello.Api.Database;
using Trello.Shared.DTOs;

namespace Trello.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplateController(AppDbContext context) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<List<OnlyTemplateDTO>> GetallTemplates()
        {
            var response = new List<OnlyTemplateDTO>();

            var templates = context.Templates.ToList();

            foreach (var template in templates)
            {
                response.Add(new OnlyTemplateDTO { ID = template.ID, Name = template.Name });
            }

            return await Task.FromResult(response);
        }
    }
}
