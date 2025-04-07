using System.ComponentModel.DataAnnotations;

namespace MicroBlog.Models;

public class LoginViewModel
{
    [Required]
    public string Email { get;set; } = default!;

    [Required]
    public string Password { get;set; } = default!;

    public string? ReturnUrl { get;set; }
}