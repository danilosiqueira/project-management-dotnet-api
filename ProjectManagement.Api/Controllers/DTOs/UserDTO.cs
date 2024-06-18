namespace ProjectManagement.Api.Controllers.DTOs;

public class UserDTO
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Login { get; set; }
    public DateTime CreatedAt { get; set; }
}