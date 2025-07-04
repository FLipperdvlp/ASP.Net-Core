namespace Middleware.Middlewares;

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
public static class LoggingMiddlewareExtension 
{
    public static void UseLogging(this IApplicationBuilder app)
    {
        app.UseMiddleware<LoggingMiddleware>();
    }
}