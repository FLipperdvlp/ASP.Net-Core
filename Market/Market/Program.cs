// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();
//
// app.MapGet("/", () => "Hello World!");
//
// app.Run();

using Market.Enums;
using Market.Persistence;
using Market.Services;

var dbContext = new MarketContext();
var productService = new ProductService(dbContext);

productService.AddProduct("Milk", 50, 10, ProductCategory.Food);
productService.AddProduct("smth", 10, 100, ProductCategory.Cosmetics);

foreach (var product in productService.GetAllProducts())
{
    Console.WriteLine($"Product {product.Id} - {product.Name}");
}