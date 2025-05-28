using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class LoginViewModel
{
    [Required]
    public string Email { get;set; } = default!;

    [Required]
    public string Password { get;set; } = default!;

    public string? ReturnUrl { get;set; }
}