using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Interfaces;

public interface IUserRepository
{
    Task<IdentityResult> CreateUserAsync(User user, string password);
    Task<IdentityResult> UpdateUserAsync(User user);
    Task<IdentityResult> UpdateUserPasswordAsync(User user, string currentPassword, string newPassword);
    Task<User>? FindUserByEmailAsync(string email);
    Task<User>? FindUserByUsernameAsync(string username);
    Task<User>? FindUserByIdAsync(int id);
}
