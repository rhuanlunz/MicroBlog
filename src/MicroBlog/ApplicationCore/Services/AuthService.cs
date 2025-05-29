using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Services;

public class AuthService : IAuthService
{
    private readonly SignInManager<User> _signInManager;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AuthService(
        SignInManager<User> signInManager,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _signInManager = signInManager;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task LoginAsync(LoginDTO loginDto)
    {
        var user = await _userRepository.FindUserByEmailAsync(loginDto.Email);
        if (user == null)
        {
            throw new NullReferenceException("User not exist!");
        }

        var signInResult = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
        if (!signInResult.Succeeded)
        {
            throw new Exception("Login error! Email or password incorrect.");
        }
    }

    public async Task LogOut()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<IdentityResult> RegisterAsync(RegisterDTO registerDto)
    {
        var user = _mapper.Map<User>(registerDto);

        return await _userRepository.CreateUserAsync(user, registerDto.Password);
    }
}
