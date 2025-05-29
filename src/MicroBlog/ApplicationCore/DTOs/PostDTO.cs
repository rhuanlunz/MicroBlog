namespace ApplicationCore.DTOs;

public class PostDTO
{
    public int Id { get; set; }
    public string Username { get; set; } = default!;
    public int TotalLikes { get; set; }
    public string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
}
