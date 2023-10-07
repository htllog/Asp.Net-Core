using Microsoft.AspNetCore.Mvc;

namespace WebCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public string Hello()
    {
        return "hello world";
    }
}
