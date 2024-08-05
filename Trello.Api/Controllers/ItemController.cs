﻿using Microsoft.AspNetCore.Mvc;
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
