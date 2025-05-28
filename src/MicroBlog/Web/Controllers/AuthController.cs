using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("/auth")]
[AllowAnonymous]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }

    // POST: /auth/register
    [HttpPost("register")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Register([FromForm] RegisterDTO registerDto)
    {
        if (!ModelState.IsValid)
        {
            return View(registerDto);
        }

        var registerUserResult = await _authService.RegisterAsync(registerDto);

        if (!registerUserResult.Succeeded)
        {
            foreach (var error in registerUserResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(registerDto);
        }

        return RedirectToAction("Login");
    }

    // POST: /auth/login
    [HttpPost("login")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login([FromForm] LoginDTO loginDto)
    {
        try
        {
            await _authService.LoginAsync(loginDto);

            return RedirectToAction();
        }
        catch (Exception error)
        {
            ModelState.AddModelError(string.Empty, error.Message);

            return View(loginDto);
        }
    }

    // GET: /auth/logout
    [HttpGet("logout")]
    public async Task<ActionResult> LogOut()
    {
        await _authService.LogOut();

        return RedirectToAction("Login");
    }
}
