using Backend_Hotel_Management.Models;
using Backend_Hotel_Management.Properties.Data.Interfaces;
using MongoDB.Driver;

namespace Backend_Hotel_Management.Properties.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _products;

    public ProductRepository(MongoDbContext context)
    {
        _products = context.Products;
    }

    //Returns products based on the params specified are
    //all available products if criteria are absent
    public async Task<IEnumerable<Product>> GetProducts(int pageIndex, int pageSize, List<string>? categoryNames)
    {
        var filter = Builders<Product>.Filter.Empty;
        if (categoryNames is { Count: > 0 } && categoryNames[0] != null)
        {
            filter = Builders<Product>.Filter.In(p => p.CategoryName, categoryNames);
        }

        return await _products.Find(filter)
            .Skip(pageIndex * pageSize)
            .Limit(pageSize)
            .ToListAsync();
    }

    //Returns product by Id
    public async Task<Product> GetProductById(string id)
    {
        return await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    //Creates a new product
    public async Task CreateProduct(Product product)
    {
        await _products.InsertOneAsync(product);
    }

    //Updates a product
    public async Task<bool> UpdateProduct(Product product)
    {
        var updateResult = await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    //Deletes a product
    public async Task<bool> DeleteProduct(string id)
    {
        var deleteResult = await _products.DeleteOneAsync(p => p.Id == id);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}