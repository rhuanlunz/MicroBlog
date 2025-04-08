using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroBlog.Controllers;

[AllowAnonymous]
[Route("/")]
public class HomeController() : Controller
{
    public IActionResult Home()
    {
        return View();
    }
}