using System.Security.Claims;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Interfaces;

public interface IUserRepository
{
    Task<IdentityResult> CreateUser(User user, string password);
    Task<User>? FindUserByEmail(string email);
    Task<int> GetUserId(ClaimsPrincipal user);
}
