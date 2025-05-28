namespace ApplicationCore.DTOs;

public class PostDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Likes { get; set; } = 0;
    public string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
}
