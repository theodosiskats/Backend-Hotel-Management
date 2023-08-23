using Microsoft.AspNetCore.Mvc;

namespace Backend_Hotel_Management.Controllers;

//Adds the "api/" to all controllers endpoints
[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase { }