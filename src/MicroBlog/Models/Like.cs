namespace MicroBlog.Models;

public class Like
{
    public int Id { get;set; }
    public int PostId { get;set; }
    public string UserId { get;set; } = default!;
}