using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Business;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly UserBusiness _userBusiness;

    public UserController(UserBusiness userBusiness)
    {
        _userBusiness = userBusiness;
    }

    [HttpGet("{id}")]
    public Task<User?> Get(long id)
    {
        return _userBusiness.GetAsync(id);
    }

    [HttpPost]
    public Task<User?> Post([FromBody] User user)
    {
        return _userBusiness.SaveAsync(user);
    }

    [HttpPut("{id}")]
    public Task<User?> Put(long id, [FromBody] User user)
    {
        user.Id = id;
        return _userBusiness.UpdateAsync(user);
    }
}
