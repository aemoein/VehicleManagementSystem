using Microsoft.AspNetCore.Mvc;

namespace VehicleManagementSystem.Backend.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetWelcomeMessage()
        {
            return Ok("Welcome to the Vehicle Management System!");
        }
    }
}