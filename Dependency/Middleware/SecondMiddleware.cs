using Dependency.Middleware.Services;

namespace Dependency.Middleware;

public class SecondMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context, Counter  counter, MyLogger logger)
    {
        context.Response.Headers["SecondtKey"] = "Hello";
        
        logger.Log($"Second middleware set count to {++counter.Count}\n========================");
        await next.Invoke(context);
    }
}