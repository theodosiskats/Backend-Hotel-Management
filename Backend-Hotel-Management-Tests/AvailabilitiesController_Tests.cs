using Backend_Hotel_Management.Controllers;
using Backend_Hotel_Management.Models;
using Backend_Hotel_Management.Properties.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Backend_Hotel_Management_Tests;

public class AvailabilitiesControllerTests
{
    private readonly Mock<IAvailabilityRepository> _mockRepo;
    private readonly AvailabilitiesController _controller;

    public AvailabilitiesControllerTests()
    {
        _mockRepo = new Mock<IAvailabilityRepository>();
        _controller = new AvailabilitiesController(_mockRepo.Object);
    }

    [Fact]
    public async Task CreateAvailability_ReturnsOk_WhenCreationIsSuccessful()
    {
        var availability = new Availability();

        _mockRepo.Setup(repo => repo.CreateAvailability(availability))
            .Returns(Task.CompletedTask);

        var result = await _controller.CreateAvailability(availability);

        Assert.IsType<OkResult>(result);
    }
}