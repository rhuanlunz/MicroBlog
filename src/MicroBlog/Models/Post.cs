using System.ComponentModel.DataAnnotations;

namespace MicroBlog.Models;

public class Post 
{
    public int Id { get;set; }
    public string UserId { get;set; } = default!;
    public DateTime CreatedAt { get;set; } = DateTime.UtcNow;
    public int Likes { get;set; } = 0;

    [Required]
    [Length(1, 500)]
    public string Content { get;set; } = default!;

    public void AddLike() => Likes++;
    public void RemoveLike() => Likes = Math.Max(0, Likes - 1);
}