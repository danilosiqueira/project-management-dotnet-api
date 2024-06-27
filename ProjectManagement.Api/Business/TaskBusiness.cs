using ProjectManagement.Api.Repositories;

namespace ProjectManagement.Api.Business;

public class TaskBusiness
{
    private readonly IRequestContext _requestContext;
    private readonly TaskRepository _taskRepository;
    private readonly ResourceRepository _resourceRepository;

    public TaskBusiness(
        IRequestContext requestContext, 
        TaskRepository taskRepository,
        ResourceRepository resourceRepository)
    {
        _requestContext = requestContext;
        _taskRepository = taskRepository;
        _resourceRepository = resourceRepository;
    }

    public Task<Models.Task?> GetAsync(long id)
    {
        return _taskRepository.GetAsync(id);
    }

    public async Task<object?> SaveAsync(Models.Task task)
    {
        if (task.DueDate is not null && task.DueDate < task.CreatedAt)
            return new Validation("Due date cannot be before than created at.");

        if (task.AssignedTo is not null)
        {
            var resourceExists = await _resourceRepository.ExistsAsync((long) task.AssignedTo);

            if (!resourceExists)
                return new Validation("Assignee not found.");

            var assignedTask = await _taskRepository.GetOpenByAssigneeAsync((long) task.AssignedTo);

            if (assignedTask is not null)
                return new Validation("Assignee is working in another task.");
        }

        task.UserId = _requestContext.GetUserId();

        return await _taskRepository.SaveAsync(task);
    }

    public Task<Models.Task?> UpdateAsync(Models.Task task)
    {
        return _taskRepository.UpdateAsync(task);
    }
}