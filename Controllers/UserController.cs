using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Business;
using ProjectManagement.Controllers.DTOs;
using ProjectManagement.Models;
using ProjectManagement.Services;

namespace ProjectManagement.Controllers;

[ApiController]
[Route("users")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IConfiguration _config;
	private readonly IMapper _mapper;
    private readonly UserBusiness _userBusiness;

    public UserController(
        IConfiguration config, 
        IMapper mapper, 
        UserBusiness userBusiness)
    {
        _config = config;
        _mapper = mapper;
        _userBusiness = userBusiness;
    }

    [HttpPost("signup")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUp([FromBody] User user)
    {
        throw new Exception("blah.");
        var result = await _userBusiness.SaveAsync(user);

        if (result is Error error)
            return BadRequest(error.Message);

        var createdUser = result as User;
        return Ok(_mapper.Map<UserDTO>(createdUser));
    }

    [HttpPost("signin")]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn([FromBody] User user)
    {
        var token = JWTService.GenerateToken(_config["JWTSecret"], user.Login);
        return Ok(token);
    }
}
