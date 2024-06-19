using ProjectManagement.Api.Models;
using ProjectManagement.Api.Repositories;

namespace ProjectManagement.Api.Business;

public class ProjectBusiness
{
    private readonly IRequestContext _requestContext;
    private readonly IProjectRepository _projectRepository;

    public ProjectBusiness(IRequestContext requestContext, IProjectRepository projectRepository)
    {
        _requestContext = requestContext;
        _projectRepository = projectRepository;
    }

    public Task<Project?> GetAsync(long id)
    {
        return _projectRepository.GetAsync(id);
    }

    public async Task<object?> SaveAsync(Project project)
    {
        project.UserId = _requestContext.GetUserId();
        return await _projectRepository.SaveAsync(project);
    }

    public async Task<object?> UpdateAsync(long id, Project project)
    {
        var savedProject = await _projectRepository.GetAsync(id);

        if (savedProject is null)
            return new Validation("Project not found.");

        if (_requestContext.GetUserId() != savedProject.UserId)
            return new UnauthorizedValidation("Project is not owned you.");

        return await _projectRepository.UpdateAsync(project);
    }
}