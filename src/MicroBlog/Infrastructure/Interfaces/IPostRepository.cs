using Infrastructure.Entities;

namespace Infrastructure.Interfaces;

public interface IPostRepository
{
    Task CreatePostAsync(Post newPost);
    Task<List<Post>> GetAllPostsAsync();
    Task<Post> GetPostByIdAsync(int postId);
    Task<List<Post>> GetPostsByUsernameAsync(string username);
    Task DeletePostAsync(Post post);
    Task UpdatePostAsync(Post updatedPost);
}
