using ProjectManagement.Api.Models;
using ProjectManagement.Api.Repositories;

namespace ProjectManagement.Api.Business;

public class TaskBusiness
{
    private readonly TaskRepository _taskRepository;

    public TaskBusiness(TaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public Task<Models.Task?> GetAsync(long id)
    {
        return _taskRepository.GetAsync(id);
    }

    public Task<Models.Task?> SaveAsync(Models.Task task)
    {
        return _taskRepository.SaveAsync(task);
    }

    public Task<Models.Task?> UpdateAsync(Models.Task task)
    {
        return _taskRepository.UpdateAsync(task);
    }
}