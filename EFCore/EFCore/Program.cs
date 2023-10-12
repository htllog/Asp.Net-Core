using EFCore;
using EFCore.Data;
using EFCore.SeedData;

public class Program
{
    public static void Main(string[] args)
    {
        // 种子数据
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated(); // Ensure database is created
                DbInitializer.Initialize(context); // Seed data
            }
            catch (Exception e)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(e, "An error occurred while seeding the database.");
            }
        }
        
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    
}