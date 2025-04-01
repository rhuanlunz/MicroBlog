using System.ComponentModel.DataAnnotations;

namespace MicroBlog.Models;

public class RegisterViewModel
{
    [Required]
    public string Username { get;set; } = default!;
    
    [Required]
    public string Email { get;set; } = default!;

    [Required]
    public string Password { get;set; } = default!;
}