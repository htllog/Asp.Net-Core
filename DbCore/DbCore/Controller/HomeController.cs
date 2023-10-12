using Microsoft.AspNetCore.Mvc;

namespace DbCore.Controller;

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