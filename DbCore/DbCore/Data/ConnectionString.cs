namespace DbCore.Data;

public class ConnectionString
{
    public string Value { get; }

    public ConnectionString(IConfiguration configuration)
    {
        Value = configuration.GetConnectionString("DefaultConnectionString");
    }
}