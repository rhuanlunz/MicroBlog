namespace Infrastructure.Entities;

public class Post
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TotalLikes { get; set; } = 0;
    public string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; } = default!;
    public ICollection<Like> Likes { get; set; } = [];

    public void AddLike() => TotalLikes++;
    public void RemoveLike() => TotalLikes = Math.Max(0, TotalLikes - 1);
}