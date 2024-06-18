using ProjectManagement.Api.Models;
using ProjectManagement.Api.Repositories;

namespace ProjectManagement.Api.Business;

public class ResourceTypeBusiness
{
    private readonly ResourceTypeRepository _resourceTypeRepository;

    public ResourceTypeBusiness(ResourceTypeRepository resourceTypeRepository)
    {
        _resourceTypeRepository = resourceTypeRepository;
    }

    public Task<ResourceType?> GetAsync(long id)
    {
        return _resourceTypeRepository.GetAsync(id);
    }

    public Task<ResourceType?> SaveAsync(ResourceType resourceType)
    {
        return _resourceTypeRepository.SaveAsync(resourceType);
    }

    public Task<ResourceType?> UpdateAsync(ResourceType resourceType)
    {
        return _resourceTypeRepository.UpdateAsync(resourceType);
    }
}