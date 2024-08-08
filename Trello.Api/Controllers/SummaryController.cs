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
        return await Task.FromResult(await context.Tags.Include(t => t.Items).Select(t => new SummaryByTagsResponse
        {
            Color = t.BackgroundColor,
            Count = t.Items.Count,
            Tag = t.Name,
        }).ToListAsync());
    }

    [HttpGet("date")]
    public async Task<List<SummaryByDateResponse>> SummaryByDates()
    {
        List<SummaryByDateResponse> respone = [];

        var first = await context.Items.Where(i => i.DoneDate != null).OrderBy(i => i.DoneDate).FirstOrDefaultAsync();

        DateOnly today = DateOnly.FromDateTime(DateTime.Now);

        // no task has been completed
        // fill with dates minus 30 days
        if (first == null)
        {
            for (DateOnly date = today.AddDays(-30); date < today; date = date.AddDays(1))
            {
                respone.Add(new SummaryByDateResponse
                {
                    Date = date,
                    Count = 0
                });
            }
        }
        else
        {
            for (DateOnly date = (DateOnly)first.DoneDate; date < today; date = date.AddDays(1))
            {
                var count = context.Items.Where(i => i.DoneDate != null && i.DoneDate == date).Count();
                respone.Add(new SummaryByDateResponse
                {
                    Date = date,
                    Count = count,
                });
            }
        }

        return await Task.FromResult(respone);
    }

    [HttpGet("templates")]
    public async Task<List<SummaryByTemplateResponse>> SummaryByTemplates()
    {
        List<SummaryByTemplateResponse> response = [];

        var templates = await context.Templates.ToListAsync();

        foreach (var template in templates)
        {
            response.Add(new SummaryByTemplateResponse
            {
                TemplateName = template.Name,
                Count = context.Projects.Where(p => p.TemplateID == template.ID).Count()
            });
        }

        return await Task.FromResult(response);
    }

    [HttpGet]
    public async Task<SummaryGeneralResponse> GeneralSummary()
    {
        var response = new SummaryGeneralResponse
        {
            TotalProjects = context.Projects.Count(),

            TotalTasks = context.Items.Count(),

        };

        var task = context.Items.Include(i => i.Project).Where(i => i.DoneDate != null).OrderByDescending(i => i.DoneDate).FirstOrDefault();

        if (task == null)
        {
            response.LastDoneTask = null;
        }
        else
        {
            response.LastDoneTask = new LastDoneTask(task.Name, task.DoneDate, task.Project.Name, task.ProjectID);
        }

        return await Task.FromResult(response);
    }
}
