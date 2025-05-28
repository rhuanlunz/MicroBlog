using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class ProfileViewModel
{
    public string Id { get;set; } = default!;
    
    [Required]
    public string Username { get;set; } = default!;
    
    [Required]
    [EmailAddress]
    public string Email { get;set; } = default!;

    public string? Description { get;set; }
}