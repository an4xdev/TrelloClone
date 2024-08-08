using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trello.Api.Database;
using Trello.Shared.Responses;

namespace Trello.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SummaryController(AppDbContext context) : ControllerBase
{
    [HttpGet("tags")]
    public async Task<List<SummaryByTagsResponse>> SummaryByTags()
    {
        List<SummaryByTagsResponse> response = [];

        await context.Tags.Include(t => t.Items).ForEachAsync(t =>
        {
            response.Add(new SummaryByTagsResponse
            {
                Color = t.BackgroundColor,
                Count = t.Items.Count,
                Tag = t.Name,
            });
        });

        return await Task.FromResult(response);
    }

    [HttpGet("date")]
    public async Task<List<SummaryByDateResponse>> SummaryByDates()
    {
        return await Task.FromResult(context.Items.Where(i => i.DoneDate != null).GroupBy(i => i.DoneDate).Select(i => new SummaryByDateResponse { Date = i.Key, Count = i.Count() }).ToList());
    }
}
