using Backend_Hotel_Management.Controllers;
using Backend_Hotel_Management.Models;
using Backend_Hotel_Management.Properties.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Backend_Hotel_Management_Tests;

public class ProductsControllerTests
{
    private readonly Mock<IProductRepository> _mockRepo;
    private readonly ProductsController _controller;

    public ProductsControllerTests()
    {
        _mockRepo = new Mock<IProductRepository>();
        _controller = new ProductsController(_mockRepo.Object);
    }

    [Fact]
    public async Task GetProducts_ReturnOk_WithListOfProducts()
    {
        _mockRepo.Setup(repo => repo.GetAllProducts(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<List<string>>()))
            .ReturnsAsync(new List<Product>());

        var result = await _controller.GetProducts(0, 10, null);

        Assert.IsType<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        Assert.IsType<List<Product>>(okResult?.Value);
    }

    [Fact]
    public async Task GetProductById_ReturnsOk_WithProduct()
    {
        _mockRepo.Setup(repo => repo.GetProductById(It.IsAny<string>()))
            .ReturnsAsync(new Product());

        var result = await _controller.GetProductById("testId");

        Assert.IsType<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        Assert.IsType<Product>(okResult?.Value);
    }

    [Fact]
    public async Task GetProductById_ReturnsNotFound_WithProductIsNull()
    {
        _mockRepo.Setup(repo => repo.GetProductById(It.IsAny<string>()))
            .ReturnsAsync((Product)null!);

        var result = await _controller.GetProductById("testId");

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task CreateProduct_ReturnsOk()
    {
        var product = new Product();

        _mockRepo.Setup(repo => repo.CreateProduct(product))
            .Returns(Task.CompletedTask);

        var result = await _controller.CreateProduct(product);

        Assert.IsType<OkResult>(result);
    }
    
    [Fact]
    public async Task UpdateProduct_ReturnsNoContent_WhenUpdateSucceeds()
    {
        _mockRepo.Setup(repo => repo.UpdateProduct(It.IsAny<Product>()))
            .ReturnsAsync(true);

        var result = await _controller.UpdateProduct(new Product());

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task UpdateProduct_ReturnsBadRequest_WhenUpdateFails()
    {
        _mockRepo.Setup(repo => repo.UpdateProduct(It.IsAny<Product>()))
            .ReturnsAsync(false);

        var result = await _controller.UpdateProduct(new Product());

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task DeleteProduct_ReturnsOk_WhenDeleteSucceeds()
    {
        _mockRepo.Setup(repo => repo.DeleteProduct(It.IsAny<string>()))
            .ReturnsAsync(true);

        var result = await _controller.DeleteProduct("testId");

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DeleteProduct_ReturnsBadRequest_WhenDeleteFails()
    {
        _mockRepo.Setup(repo => repo.DeleteProduct(It.IsAny<string>()))
            .ReturnsAsync(false);

        var result = await _controller.DeleteProduct("testId");

        Assert.IsType<BadRequestObjectResult>(result);
    }
    
}