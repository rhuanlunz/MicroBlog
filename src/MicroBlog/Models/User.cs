using Microsoft.AspNetCore.Identity;

namespace MicroBlog.Models;

public class User : IdentityUser
{
    public string? Description { get;set; } = default;
}