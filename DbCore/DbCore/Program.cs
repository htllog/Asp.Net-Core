using DbCore;
using DbCore.Data;
using DbCore.DbUp;
using DbCore.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
        
        new DbRunner(new ConnectionString(configuration)).RunMigration();

        using (var dataManager = new ProductsDataManager(configuration))
        {
           // dataManager.AddProduct("Demo5", 49.9m);

            var addedProduct = dataManager.GetProduct(5);
            Console.WriteLine("Added Product:");
            Console.WriteLine($"Product ID: {addedProduct.ProductId}, Name: {addedProduct.Name}, Price: {addedProduct.Price}");
        }
        
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuildr => { webBuildr.UseStartup<Startup>(); });
}