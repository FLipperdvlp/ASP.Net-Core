using Market.Entities;
using Market.Enums;
using Market.Persistence;

namespace Market.Services;

public class ProductService(MarketContext dbContext)
{
    public IEnumerable<Product> GetAllProducts()
        => dbContext.Products;

    public Product AddProduct(string name, decimal price, int amount ,ProductCategory  category)
    {
        var newProduct = new Product
        {
            Name = name,
            Price = price,
            Amount = amount,
            Category = category
        };
        
        dbContext.Products.Add(newProduct);
        dbContext.SaveChanges();
        
        return newProduct;
    }
}