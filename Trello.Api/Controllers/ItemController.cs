using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trello.Api.Database;
using Trello.Api.Models;
using Trello.Shared.Requests;
using Trello.Shared.Responses;

namespace Trello.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController(AppDbContext context) : ControllerBase
{

    [HttpPost]
    public async Task<AddItemResponse> AddItem(AddItemRequest request)
    {
        var response = new AddItemResponse();

        var project = await context.Projects.Where(p => p.ID == request.ProjectID).FirstOrDefaultAsync();

        if (project == null)
        {
            response.IsSuccess = false;
            response.Message = "Unknown project";
            return await Task.FromResult(response);
        }

        var category = await context.Columns.Where(c => c.ID == request.ColumnID).FirstOrDefaultAsync();

        if (category == null)
        {
            response.IsSuccess = false;
            response.Message = "Unknow category.";
            return await Task.FromResult(response);
        }

        var item = new Item { Name = request.Name, Description = request.Description, ProjectID = request.ProjectID, Project = project, ColumnID = request.ColumnID, Column = category };

        context.Items.Add(item);


        foreach (var tagID in request.TagIDs)
        {
            var tag = await context.Tags.Where(t => t.ID == tagID).FirstOrDefaultAsync();

            if (tag == null)
            {
                response.IsSuccess = false;
                response.Message = "Unknown tag assigned to task.";
                return await Task.FromResult(response);
            }

            context.ItemTags.Add(new ItemTag
            {
                Item = item,
                ItemID = item.ID,
                Tag = tag,
                TagID = tag.ID,
            });
        }

        int added = await context.SaveChangesAsync();

        if (added == 0)
        {
            response.IsSuccess = false;
            response.Message = "An error occurred during adding task.";
            return await Task.FromResult(response);
        }

        response.IsSuccess = true;
        response.Message = "The task was successfully added";
        response.AddedID = item.ID;

        return await Task.FromResult(response);
    }

    [HttpPut]
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

        foreach (var tagID in request.AddedTags)
        {
            var tag = context.Tags.Where(t => t.ID == tagID).FirstOrDefault();
            if (tag == null)
            {
                response.IsSuccess = false;
                response.Message = "Unknown tag to add to task.";
                return await Task.FromResult(response);
            }

            context.ItemTags.Add(new ItemTag
            {
                Item = item,
                ItemID = item.ID,
                Tag = tag,
                TagID = tagID,
            });
        }

        foreach (var tagID in request.DeletedTags)
        {
            var tag = context.Tags.Where(t => t.ID == tagID).FirstOrDefault();
            if (tag == null)
            {
                response.IsSuccess = false;
                response.Message = "Unknown tag to delete from task.";
                return await Task.FromResult(response);
            }

            var it = context.ItemTags.Where(it => it.ItemID == item.ID && it.TagID == tagID).FirstOrDefault();

            if (it == null)
            {
                response.IsSuccess = false;
                response.Message = "This task was not assigned such a tag.";
                return await Task.FromResult(response);
            }

            context.ItemTags.Remove(it);
        }

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

    [HttpPut("column")]
    public async Task<DefaultResponse> ChangeColumn(ChangeItemColumnRequest request)
    {
        DefaultResponse response = new();

        var item = await context.Items.Where(i => i.ID == request.ItemID).FirstOrDefaultAsync();

        if (item == null)
        {
            response.IsSuccess = false;
            response.Message = "Unknown task in request.";
            return await Task.FromResult(response);
        }

        var column = await context.Columns.Where(c => c.ID == request.ColumnID).FirstOrDefaultAsync();

        if (column == null)
        {
            response.IsSuccess = false;
            response.Message = "Unknown column in request.";
            return await Task.FromResult(response);
        }

        item.Column = column;
        item.ColumnID = column.ID;

        if (await context.SaveChangesAsync() == 0)
        {
            response.IsSuccess = false;
            response.Message = "Error with procesing request.";
            return await Task.FromResult(response);
        }

        response.IsSuccess = true;
        response.Message = "Succesfully changed column of task.";

        return await Task.FromResult(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<DefaultResponse> DeleteTask(int id)
    {

        var response = new DefaultResponse();

        var item = await context.Items.Where(i => i.ID == id).FirstOrDefaultAsync();

        if (item == null)
        {
            response.IsSuccess = false;
            response.Message = "Unknown item to delete";
            return await Task.FromResult(response);
        }

        context.Items.Remove(item);

        int deleted = await context.SaveChangesAsync();

        if (deleted == 0)
        {
            response.IsSuccess = false;
            response.Message = "An error occurred during the task delete.";
            return await Task.FromResult(response);
        }

        response.IsSuccess = true;
        response.Message = "The task was successfully deleted.";
        return await Task.FromResult(response);
    }
}
