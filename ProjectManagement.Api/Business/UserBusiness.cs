using ProjectManagement.Api.Models;
using ProjectManagement.Api.Repositories;
using ProjectManagement.Api.Services;

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

    public async Task<object?> SigninAsync(User user)
    {
        var userSaved = await _userRepository.GetByLoginAsync(user.Login);

        if (!PasswordHasher.VerifyPassword(userSaved.Password, user.Password))
            return new Validation("Authentication failed.");

        return JWTService.GenerateToken(_config["JWTSecret"], user.Login);
    }

    public async Task<object?> SignupAsync(User user)
    {
        if (user == null)
            return new Validation("User cannot be null.");

        user.Password = PasswordHasher.HashPassword(user.Password);

        return await _userRepository.SaveAsync(user);
    }

    public Task<User?> UpdateAsync(User user)
    {
        return _userRepository.UpdateAsync(user);
    }
}