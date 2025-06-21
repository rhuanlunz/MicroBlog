using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces;

public interface IProfileService
{
    Task<ProfileDTO> ShowAsync(string username);
    Task<EditProfileDTO> EditAsync(int id);
    Task UpdateProfileInfoAsync(int id, EditProfileDTO editProfileDTO);
}
