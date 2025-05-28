using System.Security.Claims;
using ApplicationCore.DTOs;

namespace ApplicationCore.Services;

public interface IPostApiService
{
    Task<List<PostDTO>> GetAllPostsAsync();
    Task<PostDTO> GetPostByIdAsync(int postId);
    Task CreatePostAsync(CreatePostDTO newPost, ClaimsPrincipal user);
    Task DeletePostAsync(int postId, ClaimsPrincipal user);
}
