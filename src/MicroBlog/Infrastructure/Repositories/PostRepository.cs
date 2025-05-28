using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreatePostAsync(Post newPost)
    {
        _context.Posts.Add(newPost);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Post>> GetAllPostsAsync()
    {
        return await _context.Posts
            .AsNoTracking()
            .OrderByDescending(post => post.CreatedAt)
            .ToListAsync();
    }

    public async Task<Post> GetPostByIdAsync(int postId)
    {
        return await _context.Posts
            .AsNoTracking()
            .FirstOrDefaultAsync(post => post.Id == postId);
    }

    public async Task DeletePostAsync(Post post)
    {
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
    }
}