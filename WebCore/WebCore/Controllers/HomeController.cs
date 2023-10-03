using Microsoft.AspNetCore.Mvc;

namespace WebCore.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Content("Hello from HomeController");
    }
}