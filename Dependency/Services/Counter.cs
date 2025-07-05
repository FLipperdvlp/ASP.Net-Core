namespace Dependency.Middleware.Services;

public class Counter
{
    public int Count { get; set; }

    public Counter()
    {
        Console.WriteLine("New counter created!");
    }
}