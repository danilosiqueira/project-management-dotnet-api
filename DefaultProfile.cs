using AutoMapper;
using ProjectManagement.DTOs;
using ProjectManagement.Models;

namespace ProjectManagement;

public class DefaultProfile : Profile
{
	public DefaultProfile()
	{
		CreateMap<User, UserDTO>();
	}
}