using DbCore;
using DbCore.DbUp;

public class Program
{
    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
        
        // 从配置文件获取链接字符串
        string connectionString = configuration.GetConnectionString("DefaultConnectionString");
        
        // 初始化 DbRunner
        var dbRunner = new DbRunner(connectionString);
        
        // 执行数据库迁移
        dbRunner.RunMigration();
        
        // 执行数据库升级
        dbRunner.RunUpgrade();
        
        // 执行自定义 DbUp 操作
        dbRunner.CustomDbUpOperation();
        
        // 继续执行应用程序的主体逻辑
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuildr => { webBuildr.UseStartup<Startup>(); });
}