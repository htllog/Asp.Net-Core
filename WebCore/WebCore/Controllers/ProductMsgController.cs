using Microsoft.AspNetCore.Mvc;
using WebCore.Models;

namespace WebCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductMsgController : Controller
{
    private readonly List<Product> _products = new List<Product>
    {
        new Product {Id = 1,Name = "Product_1",Price = 100},
        new Product{Id = 2,Name = "Product_2",Price = 200}
    };

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(_products);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetProductById(int id)
    {
        var product = _products.Find(p => p.Id == id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }
}