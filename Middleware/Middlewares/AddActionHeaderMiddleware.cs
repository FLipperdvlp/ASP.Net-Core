namespace Middleware.Middlewares;

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