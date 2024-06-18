using AutoMapper;
using ProjectManagement.Api.Controllers.DTOs;
using ProjectManagement.Api.Models;

namespace ProjectManagement.Api.Config;

public class DefaultProfile : Profile
{
	public DefaultProfile()
	{
		CreateMap<User, UserDTO>();
	}
}