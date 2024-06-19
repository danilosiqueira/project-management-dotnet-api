using AutoMapper;
using ProjectManagement.Api.Controllers.DTOs;
using ProjectManagement.Api.Models;

namespace ProjectManagement.Api.Config;

public class DefaultProfile : Profile
{
	public DefaultProfile()
	{
		CreateMap<SignupIn, User>();
		CreateMap<User, SignupOut>();

		CreateMap<ProjectIn, Project>();
	}
}