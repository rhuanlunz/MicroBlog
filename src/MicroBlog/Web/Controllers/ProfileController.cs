using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("profile")]
[Authorize]
public class ProfileController : Controller
{
    [Route("create")]
    public ActionResult Create()
    {
        return View();
    }
}
