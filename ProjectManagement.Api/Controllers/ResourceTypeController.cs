using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Api.Business;
using ProjectManagement.Api.Models;

namespace ProjectManagement.Api.Controllers;

[ApiController]
[Route("resourcetypes")]
[Authorize]
public class ResourceTypesController : ControllerBase
{
    private readonly ResourceTypeBusiness _resourceTypeBusiness;

    public ResourceTypesController(ResourceTypeBusiness resourceTypeBusiness)
    {
        _resourceTypeBusiness = resourceTypeBusiness;
    }

    [HttpGet("{id}")]
    public Task<ResourceType?> Get(long id)
    {
        return _resourceTypeBusiness.GetAsync(id);
    }

    [HttpPost]
    public Task<ResourceType?> Post([FromBody] ResourceType resourceType)
    {
        return _resourceTypeBusiness.SaveAsync(resourceType);
    }

    [HttpPut("{id}")]
    public Task<ResourceType?> Put(long id, [FromBody] ResourceType resourceType)
    {
        resourceType.Id = id;
        return _resourceTypeBusiness.UpdateAsync(resourceType);
    }
}
