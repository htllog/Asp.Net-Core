using Microsoft.AspNetCore.Mvc;
using WebCore.Attributes;

namespace WebCore.Controllers;

[TimeRoute("09:00:00", "17:00:00")]
public class TimeController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok("All products");
    }
}