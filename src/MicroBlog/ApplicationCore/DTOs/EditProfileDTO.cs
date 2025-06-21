using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs;

public class EditProfileDTO
{
    [Required]
    public string Username { get; set; } = default!;
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [MaxLength(256, ErrorMessage = "The description cannot exceed 256 characters.")]
    public string? Description { get; set; }

    [Required]
    [Display(Name = "Current password")]
    public string? CurrentPassword { get; set; }

    [Display(Name = "New password")]
    public string? NewPassword { get; set; }
}