using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trello.Api.Database;
using Trello.Shared.DTOs;

namespace Trello.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController(AppDbContext context) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<List<OnlyProjectDTO>> GetMyProjects()
        {
            var response = new List<OnlyProjectDTO>();

            var projects = await context.Projects.ToListAsync();

            foreach (var project in projects)
            {
                response.Add(
                    new OnlyProjectDTO
                    {
                        Id = project.ID,
                        Name = project.Name,
                        Description = project.Description
                    });
            }

            return await Task.FromResult(response);
        }


        [HttpGet("default")]
        public async Task<ProjectDTO> GetDefaultProject()
        {
            var project = await context.Projects
                .Include(p => p.Template)
                    .ThenInclude(t => t.Columns)
                .Include(p => p.Items)
                .FirstOrDefaultAsync();

            var projectDTO = new ProjectDTO
            {
                ID = project.ID,
                Name = project.Name,
                Template = new TemplateDTO
                {
                    ID = project.Template.ID,
                    Name = project.Template.Name,
                    Columns = project.Template.Columns.Select(c => new ColumnDTO
                    {
                        ID = c.ID,
                        Name = c.Name,
                        Items = c.Items.Select(i => new ItemDTO
                        {
                            ID = i.ID,
                            Name = i.Name,
                            Description = i.Description
                        }).ToList()
                    }).ToList()
                },
                Items = project.Items.Select(i => new ItemDTO
                {
                    ID = i.ID,
                    Name = i.Name,
                    Description = i.Description
                }).ToList()
            };

            return await Task.FromResult(projectDTO);
        }
    }
}
