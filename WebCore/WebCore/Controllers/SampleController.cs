using Microsoft.AspNetCore.Mvc;

namespace WebCore.Controllers;

[Route("customRoute")]
public class SampleController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello from custom route!");
    }
}