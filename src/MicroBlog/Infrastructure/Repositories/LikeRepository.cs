using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class LikeRepository : ILikeRepository
{
    private readonly AppDbContext _context;

    public LikeRepository(AppDbContext context)
    {
        _context = context;
    }

    public bool IsPostLikedByUser(int postId, int userId)
    {
        return _context.Likes
            .AsNoTracking()
            .Include(like => like.User)
            .Include(like => like.Post)
            .Any(like => like.PostId == postId && like.UserId == userId);
    }

    public async Task<Like> GetUserLikeAsync(int postId, int userId)
    {
        return await _context.Likes
            .AsNoTracking()
            .Where(like => like.PostId == postId && like.UserId == userId)
            .FirstOrDefaultAsync();
    }

    public async Task AddLikeAsync(Like like)
    {
        _context.Likes.Add(like);

        await _context.SaveChangesAsync();
    }

    public async Task RemoveLikeAsync(Like like)
    {
        _context.Likes.Remove(like);

        await _context.SaveChangesAsync();
    }
}
