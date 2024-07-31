﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trello.Api.Database;
using Trello.Api.Models;
using Trello.Shared.DTOs;
using Trello.Shared.Requests;
using Trello.Shared.Responses;

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
                        Description = project.Description,
                        TemplateID = project.TemplateID,
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

        [HttpPost("add")]
        public async Task<AddProjectResponse> AddProject(AddProjectRequest request)
        {
            var response = new AddProjectResponse();

            Project project = new()
            {
                Name = request.Name,
                Description = request.Description,
                TemplateID = request.TemplateID,
                Template = await context.Templates.Where(t => t.ID == request.TemplateID).FirstAsync(),
            };

            context.Projects.Add(project);

            int added = await context.SaveChangesAsync();

            if (added > 0)
            {
                response.AddedID = project.ID;
                response.IsSuccess = true;
                response.Message = "Successfully added new project";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Something went wrong with creating new project";
            }

            return await Task.FromResult(response);
        }

        [HttpPost("edit")]
        public async Task<DefaultResponse> EditProject(ChangeProjectRequest request)
        {
            DefaultResponse response = new();

            var project = await context.Projects.Where(p => p.ID == request.ID).FirstAsync();

            if (project != null)
            {
                project.Name = request.Name;
                project.Description = request.Description;
                project.TemplateID = request.TemplateID;
                project.Template = await context.Templates.Where(t => t.ID == request.TemplateID).FirstAsync();

                int changed = await context.SaveChangesAsync();

                if (changed > 0)
                {
                    response.IsSuccess = true;
                    response.Message = "The project was successfully edited.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "An error occurred during the project edit.";
                }
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Unknown project to edit.";
            }

            return await Task.FromResult(response);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<DefaultResponse> DeleteProject(int id)
        {

            var response = new DefaultResponse();

            var project = await context.Projects.Where(i => i.ID == id).FirstOrDefaultAsync();

            if (project == null)
            {
                response.IsSuccess = false;
                response.Message = "Unknown project to delete";
                return await Task.FromResult(response);
            }

            context.Projects.Remove(project);

            int deleted = await context.SaveChangesAsync();

            if (deleted == 0)
            {
                response.IsSuccess = false;
                response.Message = "An error occurred during the project delete.";
                return await Task.FromResult(response);
            }

            response.IsSuccess = true;
            response.Message = "The project was successfully deleted.";
            return await Task.FromResult(response);
        }
    }
}