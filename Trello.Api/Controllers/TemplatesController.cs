using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trello.Api.Database;
using Trello.Shared;

namespace Trello.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplatesController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<TemplateWithCollumns> GetDefaultTemplate()
        {
            TemplateWithCollumns response = new();

            var template = await context.Templates.FirstAsync();

            var templateColumns = await context.ColumnTemplates.Where(tc => tc.TID == template.TemplateID).Select(tc => tc.CID).ToListAsync();

            var columns = await context.Columns.Where(c => templateColumns.Contains(c.ColumnID)).ToListAsync();

            response.Template = template;
            response.Columns = columns;

            return await Task.FromResult(response);
        }
    }
}
