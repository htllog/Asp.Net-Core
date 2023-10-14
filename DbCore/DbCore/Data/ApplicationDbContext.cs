using DbCore.Models;
using Microsoft.EntityFrameworkCore;

namespace DbCore.Data;

public class ApplicationDbContext : DbContext
{
    private readonly ConnectionString _connectionString;
    
    public ApplicationDbContext(ConnectionString connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString.Value);
    }
    
    public DbSet<Product> Products { get; set; } 
}