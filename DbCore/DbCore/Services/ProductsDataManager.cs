using DbCore.Data;
using DbCore.Models;

namespace DbCore.Services;

public class ProductsDataManager : IDisposable
{
    private readonly ApplicationDbContext _context;
    private readonly ConnectionString _connectionString;

    public ProductsDataManager(IConfiguration configuration)
    {
        _connectionString = new ConnectionString(configuration);
        _context = new ApplicationDbContext(_connectionString);
    }

    public void AddProduct(string name, decimal price)
    {
        var newProduct = new Product
        {
            Name = name,
            Price = price,
        };

        _context.Products.Add(newProduct);
        _context.SaveChanges();
    }

    public Product? GetProduct(int productId)
    {
        return _context.Products.Find(productId);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
