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
            var userProfile = await _profileService.Show(username);

            return View(userProfile);
        }
        catch (Exception error)
        {
            return NotFound(error.Message);
        }
    }

    [Route("edit")]
    public IActionResult Edit()
    {
        return View();
    }

    [Route("create")]
    public ActionResult Create()
    {
        return View();
    }
}
