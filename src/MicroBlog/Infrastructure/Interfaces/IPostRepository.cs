using Infrastructure.Entities;

namespace Infrastructure.Interfaces;

public interface IPostRepository
{
    Task CreatePostAsync(Post newPost);
    Task<List<Post>> GetAllPostsAsync();
    Task<Post> GetPostByIdAsync(int postId);
    Task DeletePostAsync(Post post);
}
