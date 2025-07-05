using System.Data;

namespace Dependency.Middleware.Services;

public class MyLogger : IDisposable
{
    private StreamWriter writer;
    private const string FilePath = "log.txt";

    public MyLogger()
    {
        writer = new StreamWriter(path: FilePath, append: true);
        Console.WriteLine($"Logger opened file {FilePath}");
    }

    public void Log(string message)
    {
        writer.WriteLine($"[{DateTime.Now}]message");
    }
    
    public void Dispose()
    {
        writer.Close();
        writer.Dispose();
        
        Console.WriteLine($"Logger closed file {FilePath}");
    }
}