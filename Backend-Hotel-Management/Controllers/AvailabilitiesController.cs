using Backend_Hotel_Management.Models;
using Backend_Hotel_Management.Properties.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Hotel_Management.Controllers;

public class AvailabilitiesController : BaseController
{
    private readonly IAvailabilityRepository _availabilityRepository;
    
    public AvailabilitiesController(IAvailabilityRepository availabilityRepository)
    {
        _availabilityRepository = availabilityRepository;
    }

    //Get all available products for specific category name in date range
    //Test with params: http://localhost:14727/api/Availabilities/string?startDate=2023-07-11&endDate=2023-07-14
    [HttpGet("{productCategory}")]
    public async Task<ActionResult<List<Product>>> GetAvailabilitiesForCategory(string productCategory,
        DateTime startDate, DateTime endDate)
    {
        try
        {
            var availableProducts = await _availabilityRepository.GetAvailabilitiesForCategory(productCategory, startDate, endDate);
            return Ok(availableProducts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }

    //Returns all products with availability within the date range
    //Test: http://localhost:14727/api/Availabilities?startDate=2023-07-11&endDate=2023-07-13
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAvailabilitiesForDateRange(DateTime startDate, DateTime endDate)
    {
        try
        {
            var availableProducts = await _availabilityRepository.GetAvailabilityForDateRange(startDate, endDate);
            return Ok(availableProducts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }

    //Creates a new availability
    [HttpPost]
    public async Task<ActionResult> CreateAvailability([FromBody] Availability availability)
    {
        try
        {
            await _availabilityRepository.CreateAvailability(availability);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }

}