using System.IdentityModel.Tokens.Jwt;
using ProjectManagement.Api.Models;
using ProjectManagement.Api.Repositories;

namespace ProjectManagement.Api.Business;

public class ProjectBusiness
{
    private readonly long _userId;
    private readonly ProjectRepository _projectRepository;

    public ProjectBusiness(IHttpContextAccessor httpContextAccessor, ProjectRepository projectRepository)
    {
        var userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        if (userIdClaim is not null)
            _userId = long.Parse(userIdClaim);

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

        if (_userId != savedProject.UserId)
            return new UnauthorizedValidation("Project is not owned you.");

        return await _projectRepository.UpdateAsync(project);
    }
}