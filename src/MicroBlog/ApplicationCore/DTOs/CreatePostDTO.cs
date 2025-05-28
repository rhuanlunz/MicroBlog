using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs;

public class CreatePostDTO
{
    [Required]
    [MaxLength(500)]
    public string Content { get; set; } = default!;
}
