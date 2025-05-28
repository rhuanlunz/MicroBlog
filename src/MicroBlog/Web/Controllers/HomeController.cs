using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[AllowAnonymous]
[Route("/")]
public class HomeController() : Controller
{
    public IActionResult Home()
    {
        return View();
    }
}