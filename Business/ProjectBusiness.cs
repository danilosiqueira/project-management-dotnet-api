using ProjectManagement.Models;
using ProjectManagement.Repositories;

namespace ProjectManagement.Business;

public class ProjectBusiness
{
    private readonly ProjectRepository _projectRepository;

    public ProjectBusiness(ProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public Task<Project?> GetAsync(long id)
    {
        return _projectRepository.GetAsync(id);
    }

    public Task<Project?> SaveAsync(Project project)
    {
        return _projectRepository.SaveAsync(project);
    }

    public Task<Project?> UpdateAsync(Project project)
    {
        return _projectRepository.UpdateAsync(project);
    }
}