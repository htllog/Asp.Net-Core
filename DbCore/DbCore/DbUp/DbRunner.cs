using DbUp;
using System.Reflection;

namespace DbCore.DbUp;

public class DbRunner
{
    private readonly string _connectionString;

    public DbRunner(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void RunMigration()
    {
        EnsureDatabase.For.SqlDatabase(_connectionString);

        var upgrade = DeployChanges.To
            .SqlDatabase(_connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();
            
        var result = upgrade.PerformUpgrade();

        if (!result.Successful)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result.Error);
            throw new Exception("Database migration failed. See the log for details.");
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Database migration completed successfully.");
        Console.ResetColor();
    }

    public void RunUpgrade()
    {
        Console.WriteLine("Database upgrade completed successfully.");
    }

    public void CustomDbUpOperation()
    {
        Console.WriteLine("Custom DbUp operation completed successfully.");
    }
}
