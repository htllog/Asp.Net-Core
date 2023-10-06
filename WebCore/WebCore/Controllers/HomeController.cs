using Microsoft.AspNetCore.Mvc;

namespace WebCore.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : Controller
{
    [HttpGet("hello")]
    public string Hello()
    {
        return "hello world";
    }
}