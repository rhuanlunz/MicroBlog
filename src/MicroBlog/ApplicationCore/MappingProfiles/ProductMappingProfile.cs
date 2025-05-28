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
            .ForMember(
                dest => dest.UserName,
                opt => opt.MapFrom(
                    src => src.Username)
            );

        CreateMap<Post, PostDTO>();
    }
}
