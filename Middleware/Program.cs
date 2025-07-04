using Middleware.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.UseLogging();
//app.UseAdminPathCheck();
//app.UseAddActionHeader();

app.UseRequestResponseLoggingMiddleware();

app.MapGet("/admin", () => "Admin Page!");
app.MapGet("time", () => DateTime.Now);
app.MapGet("/oleg",  () => "Oleg");

app.Run();

//return app.Middleware<CorsMiddleware>();