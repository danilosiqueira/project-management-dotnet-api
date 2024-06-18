using System.IdentityModel.Tokens.Jwt;
using ProjectManagement.Api.Models;
using ProjectManagement.Api.Repositories;

namespace ProjectManagement.Api.Business;

public class ProjectBusiness
{
    private readonly RequestInfo _requestInfo;
    private readonly IProjectRepository _projectRepository;

    public ProjectBusiness(RequestInfo requestInfo, IProjectRepository projectRepository)
    {
        _requestInfo = requestInfo;
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

    public async Task<object?> UpdateAsync(long id, Project project)
    {
        var savedProject = await _projectRepository.GetAsync(id);

        if (savedProject is null)
            return new Validation("Project not found.");

        if (_requestInfo.UserId != savedProject.UserId)
            return new UnauthorizedValidation("Project is not owned you.");

        return await _projectRepository.UpdateAsync(project);
    }
}