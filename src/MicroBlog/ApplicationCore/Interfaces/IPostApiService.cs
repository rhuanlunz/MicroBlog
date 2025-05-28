using ApplicationCore.DTOs;

namespace ApplicationCore.Services;

public interface IPostApiService
{
    Task<List<PostDTO>> GetAllPostsAsync();
    Task<PostDTO> GetPostByIdAsync(int postId);
    Task CreatePostAsync(CreatePostDTO newPost);
    Task DeletePostAsync(int postId);
}
