using Minecraft_server_API.DataBases;

namespace Minecraft_server_API.Classes;

public class DestroyBlockMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context, BlockDatabase db)
    {
        if (context.Request.Path == "/destroy")
        {
            var query = context.Request.Query;
            int x, y, z;

            try {
                x = int.Parse(query["x"]);
                y = int.Parse(query["y"]);
                z = int.Parse(query["z"]);
            } catch {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid coordinates");
                return;
            }
            if (!db.Exists(x, y, z)) {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Block not found");
                return;
            }
        }
        await next(context);
    }
}