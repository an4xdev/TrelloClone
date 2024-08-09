using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trello.Api.Database;
using Trello.Api.Models;
using Trello.Shared.Responses;

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

    [HttpGet("user")]
    public async Task<bool> UserWantNotifications()
    {
        var user = await context.Users.FirstOrDefaultAsync();

        if (user == null)
        {
            return await Task.FromResult(false);

        }
        return await Task.FromResult(user.Notifications);
    }

    [HttpGet("free")]
    public async Task<DayFreeResponse> IsDayFree()
    {
        DayFreeResponse response = new();

        var day = await context.DayFrees.FirstOrDefaultAsync();

        if (day == null)
        {
            response.DayFreeType = DayFreeType.DayDontSet;
            return await Task.FromResult(response);
        }

        DateOnly today = DateOnly.FromDateTime(DateTime.Now);

        if (day.Date != today)
        {
            response.DayFreeType = DayFreeType.DayDontSet;
            return await Task.FromResult(response);
        }

        response.DayFreeType = DayFreeType.DaySet;
        response.IsFree = day.IsFree;

        return await Task.FromResult(response);
    }

    [HttpPost("{free:bool}")]
    public async Task<DefaultResponse> SetDay(bool free)
    {
        DefaultResponse response = new();
        var day = await context.DayFrees.FirstOrDefaultAsync();

        DateOnly today = DateOnly.FromDateTime(DateTime.Now);

        if (day == null)
        {
            context.DayFrees.Add(new DayFree()
            {
                Date = today,
                IsFree = free
            });

            if (await context.SaveChangesAsync() != 1)
            {
                response.IsSuccess = false;
                response.Message = "An error occurred during setting free day.";
                return await Task.FromResult(response);
            }

            response.IsSuccess = true;
            return await Task.FromResult(response);
        }

        day.Date = today;
        day.IsFree = free;

        if (await context.SaveChangesAsync() != 1)
        {
            response.IsSuccess = false;
            response.Message = "An error occurred during setting free day.";
            return await Task.FromResult(response);
        }

        response.IsSuccess = true;

        return await Task.FromResult(response);
    }
}
