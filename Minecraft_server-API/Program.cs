using Minecraft_server_API.Classes;
using Minecraft_server_API.DataBases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<BlockDatabase>();

var app = builder.Build();

app.UseMiddleware<DestroyBlockMiddleware>();

app.MapPost("/build", (Block block, BlockDatabase db) =>
{
    db.Add(block);
    return Results.Ok("Block placed");
});

app.MapPost("/destroy", (int x, int y, int z, BlockDatabase db) =>
{
    db.Remove(x, y, z);
    return Results.Ok("Block destroyed");
});

app.Run();