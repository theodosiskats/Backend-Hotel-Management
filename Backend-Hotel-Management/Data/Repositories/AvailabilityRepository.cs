using Backend_Hotel_Management.Models;
using Backend_Hotel_Management.Properties.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Backend_Hotel_Management.Properties.Data.Repositories;

public class AvailabilityRepository : IAvailabilityRepository
{
    private readonly IMongoCollection<Availability> _availabilities;
    private readonly IMongoCollection<Product> _products;

    public AvailabilityRepository(MongoDbContext context)
    {
        _availabilities = context.Availabilities;
        _products = context.Products;
    }

    /// <summary>
    /// 1.Finds products with the specified category name
    /// 2.Finds availabilities that match the params
    /// 3.Separates the productIds from the availabilities found
    /// 4.Find products that their ids have been found in the availableProductIds
    /// </summary>
    /// <param name="productCategory">string</param>
    /// <param name="startDate">DateTime</param>
    /// <param name="endDate">DateTime</param>
    /// <returns>Returns a List<Product> that are available for the date range with the selected category</returns>
    public async Task<ActionResult<List<Product>>> GetAvailabilitiesForCategory(string productCategory, DateTime startDate, DateTime endDate)
    {
        var relatedProducts = await _products.Find(p => p.CategoryName == productCategory).ToListAsync();

        var availabilities = await _availabilities
            .Find(a => a.StartDate <= startDate && a.EndDate >= endDate && a.ProductCategory == productCategory)
            .ToListAsync();

        var availableProductIds = new HashSet<string>(availabilities.Select(a => a.ProductId));

        var availableProducts = relatedProducts
            .Where(p => availableProductIds.Contains(p.Id))
            .ToList();

        return availableProducts;
    }

    //Gets all products that have availability withing the specified date range
    public async Task<ActionResult<List<Product>>> GetAvailabilityForDateRange(DateTime startDate, DateTime endDate)
    {
        var products = await _products.Find(products => true).ToListAsync();
        var availabilities = await _availabilities
            .Find(a => a.StartDate <= startDate && a.EndDate >= endDate)
            .ToListAsync();

        var availableProductIds = new HashSet<string>(availabilities.Select(a => a.ProductId));

        var availableProducts = products
            .Where(p => availableProductIds.Contains(p.Id))
            .ToList();

        return availableProducts;
    }

    //Creates a new availability
    public async Task CreateAvailability(Availability availability)
    {
        await _availabilities.InsertOneAsync(availability);
    }
}