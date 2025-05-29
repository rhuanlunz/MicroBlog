using Infrastructure.Entities;

namespace Infrastructure.Interfaces;

public interface ILikeRepository
{
    bool IsPostLikedByUser(int postId, int userId);
    Task AddLikeAsync(Like like);
    Task RemoveLikeAsync(Like like);
    Task<Like> GetUserLikeAsync(int postId, int userId);
}
