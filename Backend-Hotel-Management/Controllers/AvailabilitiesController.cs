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