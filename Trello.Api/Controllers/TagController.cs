using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trello.Api.Database;
using Trello.Shared.DTOs;

namespace Trello.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TagController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<List<TagDTO>> GetAll()
    {
        return await Task.FromResult(await context.Tags.Select(t => new TagDTO
        {
            ID = t.ID,
            Name = t.Name,
            BackgroundColor = t.BackgroundColor,
            FontColor = t.FontColor,
        }).ToListAsync());
    }
}
