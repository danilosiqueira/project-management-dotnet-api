using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Business;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers;

[ApiController]
[Route("resources")]
[Authorize]
public class ResourceController : ControllerBase
{
    private readonly ResourceBusiness _resourceBusiness;

    public ResourceController(ResourceBusiness resourceBusiness)
    {
        _resourceBusiness = resourceBusiness;
    }

    [HttpGet("{id}")]
    public Task<Resource?> Get(long id)
    {
        return _resourceBusiness.GetAsync(id);
    }

    [HttpPost]
    public Task<Resource?> Post([FromBody] Resource resource)
    {
        return _resourceBusiness.SaveAsync(resource);
    }

    [HttpPut("{id}")]
    public Task<Resource?> Put(long id, [FromBody] Resource resource)
    {
        resource.Id = id;
        return _resourceBusiness.UpdateAsync(resource);
    }
}
