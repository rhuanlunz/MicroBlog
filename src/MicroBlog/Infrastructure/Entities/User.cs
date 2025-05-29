using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities;

public class User : IdentityUser<int>
{
    public string? Description { get; set; }

    public ICollection<Post> Posts { get; set; } = [];
    public ICollection<Like> Likes { get; set; } = [];
}