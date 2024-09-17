using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VelorusNet8.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        // Index metodunu GET isteği için ayarlayın
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("This is the admin index.");
        }

        // POST metodunu açıkça belirtin
        [HttpPost("create")]
        public IActionResult Create()
        {
            return Ok("Admin created.");
        }

        // Diğer metodlar için de HTTP metodlarını açıkça belirtin
    }
}
