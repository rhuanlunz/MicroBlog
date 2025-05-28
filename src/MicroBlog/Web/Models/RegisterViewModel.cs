using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class RegisterViewModel
{
    [Required]
    public string Username { get;set; } = default!;
    
    [Required]
    public string Email { get;set; } = default!;

    [Required]
    public string Password { get;set; } = default!;
}