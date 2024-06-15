using ProjectManagement.Models;
using ProjectManagement.Repositories;

namespace ProjectManagement.Business;

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