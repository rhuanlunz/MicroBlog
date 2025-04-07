using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MicroBlog.Models;

namespace MicroBlog.Controllers;

[Authorize]
[Route("profile")]
public class ProfileController(
    UserManager<User> userManager,
    SignInManager<User> signInManager) : Controller
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly SignInManager<User> _signInManager = signInManager;
    
    [HttpGet("{username?}")]
    public async Task<IActionResult> Profile(string username)
    {
        var user = await _userManager.FindByNameAsync(username);        
        
        if (user != null)
        {
            var model = new ProfileViewModel
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                Description = user.Description
            };

            return View(model);
        }

        return NotFound();
    }

    [HttpGet("edit")]
    public async Task<IActionResult> Edit()
    {
        var user = await _userManager.GetUserAsync(User);
        
        if (user != null)
        {            
            var model = new EditProfileViewModel
            {
                Username = user.NormalizedUserName,
                Email = user.NormalizedEmail,
                Description = user.Description,
                NewPassword = null
            };

            return View(model);
        }

        return NotFound();
    }

    [HttpGet("create")]
    public async Task<IActionResult> Create()
    {
        var user = await _userManager.GetUserAsync(User);
        
        if (user != null)
        {
            return View(user);
        }

        return NotFound();
    }

    [HttpPost("edit")]
    public async Task<IActionResult> Edit(EditProfileViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return NotFound();
        }

        user.UserName = model.Username;
        user.NormalizedUserName = model.Username;
        user.Email = model.Email;
        user.Description = model.Description;

        if (model.NewPassword != null && model.CurrentPassword != null)
        {
            var updatePasswordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!updatePasswordResult.Succeeded)
            {
                foreach (var error in updatePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                
                return View(model);
            }
        }

        var updateUserResult = await _userManager.UpdateAsync(user);
        if (!updateUserResult.Succeeded)
        {
            foreach(var error in updateUserResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            
            return View(model);
        }

        await _signInManager.SignOutAsync();

        await _signInManager.SignInAsync(user, isPersistent: false);

        return LocalRedirect($"/profile/{model.Username}");
    }
}