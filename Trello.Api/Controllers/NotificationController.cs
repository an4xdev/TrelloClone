using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trello.Api.Database;

namespace Trello.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<string> CheckActivity()
    {
        var first = await context.Items.Where(i => i.DoneDate != null).OrderBy(i => i.DoneDate).FirstOrDefaultAsync();

        // user didnt do anything :(
        if (first == null)
        {
            return await Task.FromResult("You have not completed any task during your entire use of the application 😢. It is possible that none of the columns in the templates you use in your projects have the \"Mark as done\" mark.");
        }

        DateOnly today = DateOnly.FromDateTime(DateTime.Now);

        var todayTasks = context.Items.Where(i => i.DoneDate != null && i.DoneDate == today).Count();

        // user didn't do something today 
        if (todayTasks == 0)
        {
            return await Task.FromResult("You didn't finish any tasks today 😔. I hope you have a column in your projects marked \"Mark as done\". Sorry if it was your day off 😢. Good luck with your projects 😁.");
        }

        // user done something today and it's first day in database marked as done.
        if (todayTasks > 0 && first == null)
        {
            return await Task.FromResult("You managed to complete some tasks for the first time today 😁. Don't stop and keep moving forward 😉.");
        }

        // user done something today and in past.
        int counter = 1;

        //for (DateOnly date = (DateOnly)first.DoneDate; date < today; date = date.AddDays(1))
        for (DateOnly date = today; date >= first.DoneDate; date = date.AddDays(-1))
        {
            if (context.Items.Where(i => i.DoneDate != null && i.DoneDate == date).Any())
            {
                counter++;
            }
            else
            {
                break;
            }
        }

        return await Task.FromResult($"Today you did some tasks 😁. Keep it up 😉. Your streak is: {counter}.");
    }
}
