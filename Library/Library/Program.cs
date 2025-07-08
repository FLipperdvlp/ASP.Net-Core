using Library.DataBase;
using Library.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryDbContext>();
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapControllers();//Direct requests to controllers


app.Run();                      