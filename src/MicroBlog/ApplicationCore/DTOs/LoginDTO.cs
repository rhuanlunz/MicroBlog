using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs;

public class LoginDTO
{
    [EmailAddress]
    [Required]
    public string Email { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
}
