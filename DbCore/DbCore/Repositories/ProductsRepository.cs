using DbCore.Data;
using DbCore.Models;

namespace DbCore.Repositories;

public class ProductRepository<T> : IProductsRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
}