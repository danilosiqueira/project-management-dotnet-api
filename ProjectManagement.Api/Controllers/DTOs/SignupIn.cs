namespace ProjectManagement.Api.Controllers.DTOs;

public class SignupIn
{
    public required string Name { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
}