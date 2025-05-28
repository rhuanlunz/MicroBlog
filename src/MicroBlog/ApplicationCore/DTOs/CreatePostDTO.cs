using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs;

public class CreatePostDTO
{
    public int UserId { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string Content { get; set; } = default!;
}
