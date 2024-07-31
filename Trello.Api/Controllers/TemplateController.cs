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

    [HttpPost("add")]
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
