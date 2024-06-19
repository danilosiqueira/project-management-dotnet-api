using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Api.Business;
using ProjectManagement.Api.Controllers.DTOs;
using ProjectManagement.Api.Models;

namespace ProjectManagement.Api.Controllers;

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
    public async Task<IActionResult> Signup([FromBody] SignupIn signupIn)
    {
        var result = await _userBusiness.SignupAsync(_mapper.Map<User>(signupIn));

        if (result is Validation validation)
            return BadRequest(validation.Message);

        return Ok(_mapper.Map<SignupOut>(result as User));
    }

    [HttpPost("signin")]
    [AllowAnonymous]
    public async Task<IActionResult> Signin([FromBody] SigninIn signinIn)
    {
        var result = await _userBusiness.SigninAsync(signinIn.Login, signinIn.Password);

        if (result is Validation validation)
            return BadRequest(validation.Message);

        return Ok(result as string);
    }
}
