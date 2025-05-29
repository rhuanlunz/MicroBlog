using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Interfaces;

public interface IUserRepository
{
    Task<IdentityResult> CreateUserAsync(User user, string password);
    Task<User>? FindUserByEmailAsync(string email);
}
