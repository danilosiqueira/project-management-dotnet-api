using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Business;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers;

[ApiController]
[Route("tasks")]
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
    public Task<Models.Task?> Post([FromBody] Models.Task task)
    {
        return _taskBusiness.SaveAsync(task);
    }

    [HttpPut("{id}")]
    public Task<Models.Task?> Put(long id, [FromBody] Models.Task task)
    {
        task.Id = id;
        return _taskBusiness.UpdateAsync(task);
    }
}
