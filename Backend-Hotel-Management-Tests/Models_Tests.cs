using Backend_Hotel_Management.Models;

namespace Backend_Hotel_Management_Tests;

public class ModelsTests
{
    [Fact]
    public void ProductPropertiesCanBeSetAndRetrieved()
    {
        var product = new Product
        {
            Id = "1",
            CategoryName = "Single Room",
            Capacity = 1,
            PricePerNight = 150.25m
        };
        
        Assert.Equal("1", product.Id);
        Assert.Equal("Single Room", product.CategoryName);
        Assert.Equal(1, product.Capacity);
        Assert.Equal(150.25m, product.PricePerNight);
    }

    [Fact]
    public void ProductCreatedAtHasDefaultValue()
    {
        var product = new Product();
        Assert.True((DateTime.Now - product.CreatedAt).TotalSeconds < 1);
    }

    [Fact]
    public void AvailabilityPropertiesCanBeSetAndRetrieved()
    {
        var startDate = new DateTime(2023, 1, 1);
        var endDate = new DateTime(2023, 1, 10);

        var availability = new Availability
        {
            Id = "1",
            ProductId = "1",
            ProductCategory = "Single Room",
            StartDate = startDate,
            EndDate = endDate
        };
        
        Assert.Equal("1", availability.Id);
        Assert.Equal("1", availability.ProductId);
        Assert.Equal("Single Room", availability.ProductCategory);
        Assert.Equal(startDate, availability.StartDate);
        Assert.Equal(endDate, availability.EndDate);
    }
}