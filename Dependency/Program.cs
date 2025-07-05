using Dependency.Middleware;
using Dependency.Middleware.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Counter>();//register class counter in container of dependency
builder.Services.AddSingleton<MyLogger>();

var app = builder.Build();

app.UseMiddleware<FirstMiddleware>();
app.UseMiddleware<SecondMiddleware>();
app.UseMiddleware<ThirdMiddleware>();


app.MapGet("/", () => "Hello World!");

app.Run();