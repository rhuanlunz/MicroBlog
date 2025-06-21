using ApplicationCore.DTOs;
using AutoMapper;
using Infrastructure.Entities;

namespace ApplicationCore.MappingProfiles;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        // DTO -> Entity
        CreateMap<PostDTO, Post>();

        CreateMap<CreatePostDTO, Post>();

        CreateMap<RegisterDTO, User>()
            .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Username));

        CreateMap<EditProfileDTO, User>()
            .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Username));

        CreateMap<LikeDTO, Like>();

        // Entity -> DTO
        CreateMap<Post, PostDTO>()
            .ForMember(dest => dest.Username, src => src.MapFrom(src => src.User.UserName));

        CreateMap<User, ProfileDTO>()
            .ForMember(dest => dest.Username, src => src.MapFrom(src => src.UserName));

        CreateMap<User, EditProfileDTO>()
            .ForMember(dest => dest.Username, src => src.MapFrom(src => src.UserName));
    }
}
