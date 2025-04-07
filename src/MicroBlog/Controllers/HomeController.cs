using MicroBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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