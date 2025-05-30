namespace ApplicationCore.DTOs;

public class ProfileDTO
{
    public int Id { get; set; }
    public string Username { get; set; } = default!;
    public string? Description { get; set; }
}
