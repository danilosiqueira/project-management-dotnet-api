using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Business;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers;

[ApiController]
[Route("projects")]
[Authorize]
public class ProjectController : ControllerBase
{
    private readonly ProjectBusiness _projectBusiness;

    public ProjectController(ProjectBusiness projectBusiness)
    {
        _projectBusiness = projectBusiness;
    }

    [HttpGet("{id}")]
    public Task<Project?> Get(long id)
    {
        return _projectBusiness.GetAsync(id);
    }

    [HttpPost]
    public Task<Project?> Post([FromBody] Project project)
    {
        return _projectBusiness.SaveAsync(project);
    }

    [HttpPut("{id}")]
    public Task<Project?> Put(long id, [FromBody] Project project)
    {
        project.Id = id;
        return _projectBusiness.UpdateAsync(project);
    }
}
