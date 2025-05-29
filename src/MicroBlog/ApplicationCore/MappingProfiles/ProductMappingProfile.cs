using ApplicationCore.DTOs;
using AutoMapper;
using Infrastructure.Entities;

namespace ApplicationCore.MappingProfiles;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<PostDTO, Post>();

        CreateMap<CreatePostDTO, Post>();

        CreateMap<RegisterDTO, User>()
            .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Username));

        CreateMap<LikeDTO, Like>();

        CreateMap<Post, PostDTO>()
            .ForMember(dest => dest.Username, src => src.MapFrom(src => src.User.UserName));
    }
}
