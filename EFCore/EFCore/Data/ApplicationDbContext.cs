using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 为用户定义表和种子数据
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Ohlin", Email = "Ohlin@example.com" },
            new User { Id = 2, Name = "Htl", Email = "HTl@example.com" });
    }
}