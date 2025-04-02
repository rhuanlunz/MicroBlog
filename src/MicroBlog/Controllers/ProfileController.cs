using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MicroBlog.Models;

namespace MicroBlog.Controllers;

[Authorize]
public class ProfileController(UserManager<User> userManager) : Controller
{
    private readonly UserManager<User> _userManager = userManager;
    
    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var user = await _userManager.GetUserAsync(User);
        
        if (user != null)
        {
            var model = new ProfileViewModel
            {
                Username = user.NormalizedUserName,
                Email = user.NormalizedEmail,
                Description = user.Description
            };

            return View(model);
        }

        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> Edit()
    {
        var user = await _userManager.GetUserAsync(User);
        
        if (user != null)
        {            
            var model = new ProfileViewModel
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

    [HttpPost]
    public async Task<IActionResult> Edit(ProfileViewModel model)
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

        return RedirectToAction("Profile");
    }
}