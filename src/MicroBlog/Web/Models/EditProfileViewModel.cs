using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class EditProfileViewModel
{
    [Required]
    public string Username { get;set; } = default!;
    
    [Required]
    [EmailAddress]
    public string Email { get;set; } = default!;

    [Display(Name = "Current password")]
    public string? CurrentPassword { get;set; }

    [Display(Name = "New password")]
    public string? NewPassword { get;set; }

    public string? Description { get;set; }
}