using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Infrastructure.Interfaces;

namespace ApplicationCore.Services;

public class ProfileService : IProfileService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ProfileService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ProfileDTO> Show(string username)
    {
        var user = await _userRepository.FindUserByUsernameAsync(username);

        if (user == null)
        {
            throw new NullReferenceException($"User {username} not found!");
        }

        var userProfile = _mapper.Map<ProfileDTO>(user);

        return userProfile;
    }
}
