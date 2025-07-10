using Library.DataBase;

var builder = WebApplication.CreateBuilder(args);
//Register
builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryDbContext>();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapControllers();//Direct requests to controllers

app.Run();                      