using DbCore.Models;
using DbCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DbCore.Controller;

/**
 * GetAllProducts: GET /api/Product
 * GetProductById: GET /api/Product/{id}
 * CreateProduct: POST /api/Product/create
 * UpdateProduct: PUT /api/Product/{id}
 * DeleteProduct: DELETE /api/Product/{id}
 */

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductsRepository<Product> _productRepository;

    public ProductController(IProductsRepository<Product> productsRepository)
    {
        _productRepository = productsRepository;
    }

    [HttpGet("")]
    public IActionResult GetAllProducts()
    {
        var products = _productRepository.GetAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost("create")]
    public IActionResult CreateProduct([FromBody] Product product)
    {
        _productRepository.Add(product);
        return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] Product product)
    {
        var existingProduct = _productRepository.GetById(id);
        if (existingProduct == null)
            return NotFound();

        // 使用产品中的值更新现有产品的属性
        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        
        // 根据需要更新其他属性
        _productRepository.Update(existingProduct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null)
            return NotFound();

        _productRepository.Remove(product);
        return NoContent();
    }
}