using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public string Hello()
    {
        return "demo";
    }
}