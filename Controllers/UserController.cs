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
	private readonly IMapper _mapper;
    private readonly UserBusiness _userBusiness;

    public UserController(
        IMapper mapper, 
        UserBusiness userBusiness)
    {
        _mapper = mapper;
        _userBusiness = userBusiness;
    }

    [HttpPost("signup")]
    [AllowAnonymous]
    public async Task<IActionResult> Signup([FromBody] User user)
    {
        var result = await _userBusiness.SignupAsync(user);

        if (result is Validation validation)
            return BadRequest(validation.Message);

        return Ok(_mapper.Map<UserDTO>(result as User));
    }

    [HttpPost("signin")]
    [AllowAnonymous]
    public async Task<IActionResult> Signin([FromBody] User user)
    {
        var result = await _userBusiness.SigninAsync(user);

        if (result is Validation validation)
            return BadRequest(validation.Message);

        return Ok(result as string);
    }
}
