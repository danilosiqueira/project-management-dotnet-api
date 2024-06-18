using ProjectManagement.Api.Models;

namespace ProjectManagement.Api.Repositories;

public interface IProjectRepository
{
    Task<Project?> GetAsync(long id);
    Task<Project?> SaveAsync(Project project);
    Task<Project?> UpdateAsync(Project Project);
}