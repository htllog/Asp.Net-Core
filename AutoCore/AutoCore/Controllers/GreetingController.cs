using AutoCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoCore.Controllers;

public class GreetingController : Controller
{
    private readonly IGreetingService _greetingService;

    public GreetingController(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    // http://localhost:5097/Greeting/SayHello?name=Ohlin
    public IActionResult SayHello(string name)
    {
        var greeting = _greetingService.Greet(name);
        return Content(greeting);
    }
}