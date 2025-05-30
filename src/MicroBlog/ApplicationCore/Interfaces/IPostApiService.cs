using ApplicationCore.DTOs;

namespace ApplicationCore.Services;

public interface IPostApiService
{
    Task<List<PostDTO>> GetAllPostsAsync();
    Task<PostDTO> GetPostByIdAsync(int postId);
    Task<List<PostDTO>> GetAllUserPostsAsync(string username);
    Task CreatePostAsync(CreatePostDTO newPost, int userId);
    Task DeletePostAsync(int postId, int userId);
    Task<int> LikePostAsync(LikeDTO likeDto);
}
