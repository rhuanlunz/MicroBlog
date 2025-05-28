using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs;

public class RegisterDTO
{
    [Required]
    [MinLength(4)]
    public string Username { get; set; } = default!;

    [EmailAddress]
    [Required]
    public string Email { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
}
