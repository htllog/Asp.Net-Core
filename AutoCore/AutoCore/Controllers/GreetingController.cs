using AutoCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoCore.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class GreetingController : Controller
{
    private readonly IGreetingService _greetingService;

    public GreetingController(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }
    
    [HttpGet]
    public IActionResult SayHello(string name)
    {
        var greeting = _greetingService.Greet(name);
        return Content(greeting);
    }
}