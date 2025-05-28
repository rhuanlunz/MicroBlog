namespace Infrastructure.Entities;

public class Post
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Likes { get; set; } = 0;
    public string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; } = default!;
}