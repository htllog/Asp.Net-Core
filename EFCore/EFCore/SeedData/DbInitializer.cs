using EFCore.Data;
using EFCore.Models;

namespace EFCore.SeedData;

public class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        // 检查是否有用户
        if (context.Users.Any())
            return; // 数据库已播种
        
        context.Users.AddRange(
            new User { Name = "Ohlin", Email = "Ohlin@example.com" },
            new User { Name = "Htl", Email = "HTl@example.com" }
            );

        context.SaveChanges();
    }
}