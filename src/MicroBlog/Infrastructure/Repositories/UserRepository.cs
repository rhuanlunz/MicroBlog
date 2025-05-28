using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;

    public UserRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> CreateUser(User user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<User>? FindUserByEmail(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }
}