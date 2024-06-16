using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Business;
using ProjectManagement.Models;
using ProjectManagement.Services;

namespace ProjectManagement.Controllers;

[ApiController]
[Route("users")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly UserBusiness _userBusiness;

    public UserController(IConfiguration config, UserBusiness userBusiness)
    {
        _config = config;
        _userBusiness = userBusiness;
    }

    [HttpPost("signup")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUp([FromBody] User user)
    {
        var blah = await _userBusiness.SaveAsync(user);

        if (blah is Error error)
            return Ok(error.Message);

        return Ok(blah as User);
    }

    [HttpPost("signin")]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn([FromBody] User user)
    {
        var token = JWTService.GenerateToken(_config["JWTSecret"], user.Login);
        return Ok(token);
    }
}
