using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trello.Api.Database;
using Trello.Api.Models;
using Trello.Shared.DTOs;
using Trello.Shared.Requests;
using Trello.Shared.Responses;

namespace Trello.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TemplateController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<List<TemplateDTO>> GetTemplates()
    {
        var response = new List<TemplateDTO>();

        var templates = context.Templates.Include(t => t.Columns);

        foreach (var template in templates)
        {
            var templateDTO = new TemplateDTO()
            {
                ID = template.ID,
                Name = template.Name,
                Columns = []
            };

            foreach (var column in template.Columns)
            {
                templateDTO.Columns.Add(new ColumnDTO() { ID = column.ID, Name = column.Name });
            }

            response.Add(templateDTO);
        }
        return await Task.FromResult(response);
    }
    [HttpGet("all")]
    public async Task<List<OnlyTemplateDTO>> GetAllTemplates()
    {
        var response = new List<OnlyTemplateDTO>();

        var templates = context.Templates.ToList();

        foreach (var template in templates)
        {
            response.Add(new OnlyTemplateDTO { ID = template.ID, Name = template.Name });
        }

        return await Task.FromResult(response);
    }

    [HttpGet("{id:int}")]
    public async Task<TemplateDTO> GetTemaplateByID(int id)
    {
        var template = await context.Templates.Where(t => t.ID == id).FirstOrDefaultAsync();

        var response = new TemplateDTO()
        {
            ID = template.ID,
            Name = template.Name,
            Columns = []
        };

        foreach (var column in template.Columns)
        {
            response.Columns.Add(new ColumnDTO() { ID = column.ID, Name = column.Name });
        }

        return await Task.FromResult(response);
    }

    [HttpPost]
    public async Task<AddTemplateResponse> AddTemplate(AddTemplateRequest request)
    {
        var response = new AddTemplateResponse();

        Template template = new()
        {
            Name = request.Name,
        };

        context.Templates.Add(template);

        if (await context.SaveChangesAsync() != 1)
        {
            response.IsSuccess = false;
            response.Message = "Error with adding template";
            response.AddedID = -1;
            return await Task.FromResult(response);
        }

        foreach (var column in request.Columns)
        {
            context.Columns.Add(new Column()
            {
                Name = column.Name,
                TemplateID = template.ID,
                Template = template
            });
        }

        if (await context.SaveChangesAsync() != request.Columns.Count)
        {
            response.IsSuccess = false;
            response.Message = "Error with adding columns to template";
            response.AddedID = -1;
            return await Task.FromResult(response);
        }

        response.IsSuccess = true;
        response.Message = "Successfully added new template";
        response.AddedID = template.ID;

        return await Task.FromResult(response);
    }

    [HttpPut]
    public async Task<DefaultResponse> Update(ChangeTemplateRequest request)
    {
        var response = new DefaultResponse();

        var template = context.Templates.Where(t => t.ID == request.ID).First();

        if (template == null)
        {
            response.IsSuccess = false;
            response.Message = "Unknow template to edit.";
            return await Task.FromResult(response);
        }

        if (request.Name != string.Empty)
        {
            template.Name = request.Name;
        }

        foreach (var c in request.DeletedColumnIDs)
        {
            var column = context.Columns.Where(cc => cc.ID == c).First();
            if (column == null)
            {
                response.IsSuccess = false;
                response.Message = "Unknown column to delete";
                return await Task.FromResult(response);
            }
            context.Columns.Remove(column);
        }

        foreach (var c in request.AddedColumns)
        {
            context.Columns.Add(new Column()
            {
                Name = c.Name,
                Template = template,
                TemplateID = template.ID,
            });
        }

        foreach (var c in request.ChangedColumns)
        {
            var col = context.Columns.Where(c => c.ID == c.ID).First();
            if (col == null)
            {
                response.IsSuccess = false;
                response.Message = "Unknown columnd to edit.";
                return await Task.FromResult(response);
            }
            col.Name = c.Name;
        }

        await context.SaveChangesAsync();

        response.IsSuccess = true;
        response.Message = $"Succesfully edited template {template.Name}.";

        return await Task.FromResult(response);
    }

    [HttpDelete("{id}")]
    public async Task<DefaultResponse> DeleteTemplate(int id)
    {

        DefaultResponse response = new();

        var template = await context.Templates.Where(t => t.ID == id).FirstOrDefaultAsync();

        if (template == null)
        {
            response.IsSuccess = false;
            response.Message = "Unsuccessfully deleted template";
            return await Task.FromResult(response);
        }

        context.Templates.Remove(template);
        response.IsSuccess = true;
        response.Message = $"Successfully deleted template {template.Name}";
        return await Task.FromResult(response);

    }
}
