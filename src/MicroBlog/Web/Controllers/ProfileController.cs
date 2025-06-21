using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("profile")]
[Authorize]
public class ProfileController : Controller
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [Route("{username}")]
    public async Task<IActionResult> Show(string username)
    {
        try
        {
            var userProfile = await _profileService.ShowAsync(username);

            return View(userProfile);
        }
        catch (Exception error)
        {
            return NotFound(error.Message);
        }
    }

    [Route("edit")]
    public async Task<IActionResult> Edit()
    {
        try
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var userProfile = await _profileService.EditAsync(userId);

            return View(userProfile);
        }
        catch (Exception error)
        {
            return NotFound(error.Message);
        }
    }

    [Route("create")]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost("edit")]
    public async Task<IActionResult> Edit([FromForm] EditProfileDTO editProfileDTO)
    {
        try
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _profileService.UpdateProfileInfoAsync(userId, editProfileDTO);

            return LocalRedirect($"/profile/{User.FindFirstValue(ClaimTypes.Name)}");
        }
        catch (Exception error)
        {
            ModelState.AddModelError(string.Empty, error.Message);

            return View(editProfileDTO);
        }
    }
}
