using Backend_Hotel_Management.Models;

namespace Backend_Hotel_Management.Properties.Data.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts(
        int pageIndex,
        int pageSize,
        List<string>? categoryNames);
    Task<Product> GetProductById(string id);
    Task CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(string id);
}