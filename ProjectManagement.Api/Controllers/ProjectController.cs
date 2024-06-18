using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Api.Business;
using ProjectManagement.Api.Models;

namespace ProjectManagement.Api.Controllers;

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
    public async Task<IActionResult> Put(long id, [FromBody] Project project)
    {
        var result = await _projectBusiness.UpdateAsync(id, project);

        if (result is Validation validation)
            return BadRequest(validation.Message);

        if (result is UnauthorizedValidation unauthorizedValidation)
            return Forbid(unauthorizedValidation.Message);

        return Ok(result as Project);
    }
}
