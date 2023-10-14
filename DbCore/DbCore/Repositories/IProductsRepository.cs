using DbCore.Models;

namespace DbCore.Repositories;

public interface IProductsRepository<T>
{
    T GetById(int id);
    
    IEnumerable<T> GetAll();
    
    void Add(T entity);
    
    void Update(T entity);
    
    void Remove(T entity);
}