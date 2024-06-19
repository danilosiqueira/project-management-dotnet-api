using AutoMapper;
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
    private readonly IMapper _mapper;
    private readonly ProjectBusiness _projectBusiness;

    public ProjectController(
        IMapper mapper, 
        ProjectBusiness projectBusiness)
    {
        _mapper = mapper;
        _projectBusiness = projectBusiness;
    }

    [HttpGet("{id}")]
    public Task<Project?> Get(long id)
    {
        return _projectBusiness.GetAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProjectIn projectIn)
    {
        var result = await _projectBusiness.SaveAsync(_mapper.Map<Project>(projectIn));

        if (result is Validation validation)
            return BadRequest(validation.Message);

        return Created("projects", result as Project);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] Project project)
    {
        var result = await _projectBusiness.UpdateAsync(id, project);

        if (result is Validation validation)
            return BadRequest(validation.Message);

        if (result is UnauthorizedValidation unauthorizedValidation)
            return Forbid();

        return Ok(result as Project);
    }
}
