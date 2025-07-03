namespace Middleware.Middleware;

public class LoggingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine($"New request to {context.Request.Path.Value}");
        Console.WriteLine($"User agent: {context.Request.Headers.UserAgent}\n==================");
        
        await next.Invoke(context);
        
        Console.WriteLine("Response status: " + context.Response.StatusCode + "\n----------");
    }
}

public static class RequestLoggingMiddlewareExtension
{
    public static void UseRequestLogging(this IApplicationBuilder app)
    {
        app.UseMiddleware<LoggingMiddleware>();
    }
}

public class AdminPathCheckMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Path.Value.EndsWith("/admin"))
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("ERROR");
            return;//not continue 
        }
        await next.Invoke(context);
    }
}

public static class AdminPathCheckMiddlewareExtension
{
    public static void UseAdminPathCheck(this IApplicationBuilder app)
    {
        app.UseMiddleware<AdminPathCheckMiddleware>();
    }
}

public class AddActionHeaderMiddleware(RequestDelegate next)
{
    private readonly string[] words = { "Mix", "Foo", "Bar", "Foobar" };
    private Random _random = new Random();
    public async Task Invoke(HttpContext context)
    {
        await next.Invoke(context);
        var word = words[_random.Next(words.Length)];
        context.Response.Headers["Action"] = word;
    }
}

public static class AddActionHeaderMiddlewareExtension
{
    public static void UseAddActionHeader(this IApplicationBuilder app)
    {
        app.UseMiddleware<AddActionHeaderMiddleware>();
    }
}