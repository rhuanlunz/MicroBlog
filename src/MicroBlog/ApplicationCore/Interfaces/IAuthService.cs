using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Interfaces;

public interface IAuthService
{
    Task LoginAsync(LoginDTO loginDto);
    Task LogOut();
    Task<IdentityResult> RegisterAsync(RegisterDTO registerDto);
}
