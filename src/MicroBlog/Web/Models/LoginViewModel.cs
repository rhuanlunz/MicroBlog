using ApplicationCore.DTOs;

namespace Web.Models;

public class LoginViewModel : LoginDTO
{
    public string? ReturnUrl { get;set; }
}