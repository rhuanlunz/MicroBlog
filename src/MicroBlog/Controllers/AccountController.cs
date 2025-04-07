using Microsoft.AspNetCore.Mvc;
using MicroBlog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MicroBlog.Controllers;

[AllowAnonymous]
[Route("account")]
public class AccountController(
    UserManager<User> userManager, 
    SignInManager<User> signInManager) : Controller
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly SignInManager<User> _signInManager = signInManager;

    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpGet("login")]
    public IActionResult Login([FromQuery] string? returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpGet("logout")]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);    
        }

        var user = new User 
        { 
            UserName = model.Username,
            Email = model.Email,
            NormalizedUserName = model.Username,
            NormalizedEmail = model.Email
        };
        var userCreationResult = await _userManager.CreateAsync(user, model.Password);

        if (!userCreationResult.Succeeded)
        {
            foreach (var error in userCreationResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        return RedirectToAction("Login");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);    
        }

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Email or password is incorrect!");
            return View(model);
        }

        var userSignInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

        if (!userSignInResult.Succeeded)
        {
            ModelState.AddModelError(string.Empty, "Email or password is incorrect!");
            return View(model);
        }

        return LocalRedirect(model.ReturnUrl ?? $"/profile/{user.NormalizedUserName.ToLower()}");
    }
}
