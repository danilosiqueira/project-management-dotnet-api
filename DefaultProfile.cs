using AutoMapper;
using ProjectManagement.Controllers.DTOs;
using ProjectManagement.Models;

namespace ProjectManagement;

public class DefaultProfile : Profile
{
	public DefaultProfile()
	{
		CreateMap<User, UserDTO>();
	}
}