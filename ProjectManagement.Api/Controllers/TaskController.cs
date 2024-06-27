using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Api.Business;

namespace ProjectManagement.Api.Controllers;

[ApiController]
[Route("tasks")]
[Authorize]
public class TaskController : ControllerBase
{
    private readonly TaskBusiness _taskBusiness;

    public TaskController(TaskBusiness taskBusiness)
    {
        _taskBusiness = taskBusiness;
    }

    [HttpGet("{id}")]
    public Task<Models.Task?> Get(long id)
    {
        return _taskBusiness.GetAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Models.Task task)
    {
        var result = await _taskBusiness.SaveAsync(task);

        if (result is Validation validation)
            return BadRequest(validation.Message);

        return Created("tasks", result as Models.Task);
    }

    [HttpPut("{id}")]
    public Task<Models.Task?> Put(long id, [FromBody] Models.Task task)
    {
        task.Id = id;
        return _taskBusiness.UpdateAsync(task);
    }
}
