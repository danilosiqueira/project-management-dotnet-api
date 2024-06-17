using ProjectManagement.Models;
using ProjectManagement.Repositories;

namespace ProjectManagement.Business;

public class UserBusiness
{
    private readonly UserRepository _userRepository;

    public UserBusiness(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User?> GetAsync(long id)
    {
        return _userRepository.GetAsync(id);
    }

    public async Task<object?> SaveAsync(User user)
    {
        if (user == null)
            return new Error("User cannot be null");

        return await _userRepository.SaveAsync(user);
    }

    public Task<User?> UpdateAsync(User user)
    {
        return _userRepository.UpdateAsync(user);
    }
}