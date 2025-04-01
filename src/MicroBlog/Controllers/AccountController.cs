using Microsoft.AspNetCore.Mvc;
using MicroBlog.Models;
using Microsoft.AspNetCore.Identity;

namespace MicroBlog.Controllers;

public class AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) : Controller
{
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly SignInManager<IdentityUser> _signInManager = signInManager;

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);    
        }

        var user = new IdentityUser { UserName = model.Username, Email = model.Email };
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

    [HttpPost]
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

        return RedirectToAction("Home", "Home");
    }
}
