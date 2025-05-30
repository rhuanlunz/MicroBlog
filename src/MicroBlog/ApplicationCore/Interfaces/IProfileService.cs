using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces;

public interface IProfileService
{
    Task<ProfileDTO> Show(string username);
}
