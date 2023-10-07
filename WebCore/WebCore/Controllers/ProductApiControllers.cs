using Microsoft.AspNetCore.Mvc;

namespace WebCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            // 请求成功 (HTTP 200 OK）
            return Ok("All products");
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok($"Product with ID: {id}");
        }
    }
}