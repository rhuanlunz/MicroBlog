using ApplicationCore.DTOs;
using AutoMapper;
using Infrastructure.Entities;

namespace ApplicationCore.MappingProfiles;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<CreatePostDTO, Post>();
        CreateMap<PostDTO, Post>();
        CreateMap<Post, PostDTO>();
    }
}
