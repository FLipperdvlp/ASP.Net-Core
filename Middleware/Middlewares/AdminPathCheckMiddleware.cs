namespace Middleware.Middlewares;

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