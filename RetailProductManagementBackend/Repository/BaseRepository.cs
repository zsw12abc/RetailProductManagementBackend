using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace RetailProductManagementBackend.Repository;

public class BaseRepository : IBaseRepository
{
    protected BaseRepository()
    {
        _ConnectionString = GetConnectionString();
    }
    
    public static string GetConnectionString()
    {
        var currentPath = System.Environment.CurrentDirectory;
        var connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        if (connectionString == null)
        {
            throw new Exception("Connection string not found");
        }

        connectionString = connectionString.Replace("{AppDir}", currentPath);
        return connectionString;
    }
}