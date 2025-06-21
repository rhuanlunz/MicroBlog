using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Services;

public class ProfileService : IProfileService
{
    private readonly IUserRepository _userRepository;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;

    public ProfileService(IUserRepository userRepository, SignInManager<User> signInManager, IMapper mapper)
    {
        _userRepository = userRepository;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    public async Task<ProfileDTO> ShowAsync(string username)
    {
        var user = await _userRepository.FindUserByUsernameAsync(username);

        if (user == null)
        {
            throw new NullReferenceException($"User {username} not found!");
        }

        var userProfile = _mapper.Map<ProfileDTO>(user);

        return userProfile;
    }
    public async Task<EditProfileDTO> EditAsync(int id)
    {
        var user = await _userRepository.FindUserByIdAsync(id);

        if (user == null)
        {
            throw new NullReferenceException($"User {id} not found!");
        }

        var userProfile = _mapper.Map<EditProfileDTO>(user);

        return userProfile;
    }

    public async Task UpdateProfileInfoAsync(int id, EditProfileDTO editProfileDTO)
    {
        var user = await _userRepository.FindUserByIdAsync(id);

        if (user == null)
        {
            throw new NullReferenceException($"User {id} not found!");
        }

        user.UserName = editProfileDTO.Username;
        user.Email = editProfileDTO.Email;
        user.Description = editProfileDTO.Description;

        var updateResult = await _userRepository.UpdateUserAsync(user);

        if (!updateResult.Succeeded)
        {
            foreach (var error in updateResult.Errors)
            {
                throw new Exception(error.Description);
            }
        }

        if (editProfileDTO.CurrentPassword == null)
        {
            throw new NullReferenceException("'Current Password' field cannot be null!");
        }

        // Update password
        if (editProfileDTO.NewPassword != null)
        {
            var passwordResult = await _userRepository.UpdateUserPasswordAsync(user, editProfileDTO.CurrentPassword, editProfileDTO.NewPassword);

            if (!passwordResult.Succeeded)
            {
                foreach (var error in passwordResult.Errors)
                {
                    throw new Exception(error.Description);
                }
            }

            await _signInManager.PasswordSignInAsync(user, editProfileDTO.NewPassword, false, false);

            return;
        }

        await _signInManager.PasswordSignInAsync(user, editProfileDTO.CurrentPassword, false, false);

        return;
    }
}