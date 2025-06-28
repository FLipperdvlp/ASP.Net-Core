var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int? a = 0;

app.MapGet("/plus", () =>
{
    a++;
    return $"a = {a}";
});
app.MapGet("/minus", () =>
{
    a--;
    return $"a = {a}";
});


app.Run();
