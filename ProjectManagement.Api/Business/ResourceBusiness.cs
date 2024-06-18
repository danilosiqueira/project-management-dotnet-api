using ProjectManagement.Api.Models;
using ProjectManagement.Api.Repositories;

namespace ProjectManagement.Api.Business;

public class ResourceBusiness
{
    private readonly ResourceRepository _resourceRepository;

    public ResourceBusiness(ResourceRepository resourceRepository)
    {
        _resourceRepository = resourceRepository;
    }

    public Task<Resource?> GetAsync(long id)
    {
        return _resourceRepository.GetAsync(id);
    }

    public Task<Resource?> SaveAsync(Resource resource)
    {
        return _resourceRepository.SaveAsync(resource);
    }

    public Task<Resource?> UpdateAsync(Resource resource)
    {
        return _resourceRepository.UpdateAsync(resource);
    }
}