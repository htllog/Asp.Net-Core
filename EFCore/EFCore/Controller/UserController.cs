using EFCore.Data;
using EFCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        var users = _context.Users;
        return Ok(users);
    }
}