using Library.DataBase;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
{
//Register
    builder.Services.AddControllers();
    builder.Services.AddDbContext<LibraryDbContext>();

// Помогает нам понимать enum как рядок
    builder.Services
        .AddControllers()
        .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });


    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("LocalFrontEnd", policy =>
        {
            policy.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader();
        });
    });
}

var app = builder.Build();
{
    app.UseCors("LocalFrontEnd");
    
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapControllers();//Direct requests to controllers
    
    
    
    app.Run();                      

}