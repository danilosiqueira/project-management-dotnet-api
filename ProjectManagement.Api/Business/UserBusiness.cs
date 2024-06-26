using ProjectManagement.Api.Models;
using ProjectManagement.Api.Repositories;
using ProjectManagement.Api.Security;

namespace ProjectManagement.Api.Business;

public class UserBusiness
{
    private readonly IConfiguration _config;
    private readonly UserRepository _userRepository;

    public UserBusiness(IConfiguration config, UserRepository userRepository)
    {
        _config = config;
        _userRepository = userRepository;
    }

    public async Task<object?> SigninAsync(string login, string password)
    {
        var user = await _userRepository.GetByLoginAsync(login);

        if (user is null)
            return new Validation("User not found.");

        if (!PasswordHasher.VerifyPassword(user.Password, password))
            return new Validation("Authentication failed.");

        return JWTService.GenerateToken(_config["JWTSecret"], user.Id.ToString());
    }

    public async Task<object?> SignupAsync(User user)
    {
        if (user == null)
            return new Validation("User cannot be null.");

        var userExists = await _userRepository.GetByLoginAsync(user.Login);
        
        if (userExists is not null)
            return new Validation("Login in use.");

        user.Password = PasswordHasher.HashPassword(user.Password);

        return await _userRepository.SaveAsync(user);
    }

    public Task<User?> UpdateAsync(User user)
    {
        return _userRepository.UpdateAsync(user);
    }
}