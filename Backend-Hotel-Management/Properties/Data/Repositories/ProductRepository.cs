using Backend_Hotel_Management.Models;
using Backend_Hotel_Management.Properties.Data.Interfaces;

namespace Backend_Hotel_Management.Properties.Data.Repositories;

public class ProductRepository : IProductRepository
{
    public Task<IEnumerable<Product>> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductById(string id)
    {
        throw new NotImplementedException();
    }

    public Task CreateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(string id)
    {
        throw new NotImplementedException();
    }
}