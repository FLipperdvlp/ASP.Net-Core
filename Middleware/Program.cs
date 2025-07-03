using Middleware.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.UseRequestLogging();
app.UseAdminPathCheck();

app.UseAddActionHeader();

app.MapGet("/admin", () => "Admin Page!");
app.MapGet("time", () => DateTime.Now);
app.MapGet("/oleg",  () => "Oleg");

app.Run();

//return app.Middleware<CorsMiddleware>();