using Backend_Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Hotel_Management.Properties.Data.Interfaces;

public interface IAvailabilityRepository
{
    Task<ActionResult<List<Product>>> GetAvailabilitiesForCategory(string productCategory, DateTime startDate, DateTime endDate);
    Task<ActionResult<List<Product>>> GetAvailabilityForDateRange(DateTime startDate, DateTime endDate);
    Task CreateAvailability(Availability availability);
}