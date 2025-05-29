namespace Infrastructure.Entities;

public class Like
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }

    public User User { get; set; } = default!;
    public Post Post { get; set; } = default!;
}
