using Dependency.Middleware.Services;

namespace Dependency.Middleware;

public class ThirdMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context, Counter  counter, MyLogger logger)
    {
        context.Response.Headers["FirstKey"] = "Hello";
        
        logger.Log($"Third middleware set count to {++counter.Count}\n========================");
        await next.Invoke(context);
    }   
}
