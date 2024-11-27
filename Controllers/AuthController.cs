using ECommerceWebAPI.Data;
using ECommerceWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // Login Endpoint
        [HttpPost("login")]
        public IActionResult Login([FromBody] Admin adminCredentials)
        {
            if (adminCredentials == null || string.IsNullOrWhiteSpace(adminCredentials.Username) || string.IsNullOrWhiteSpace(adminCredentials.Password))
            {
                return BadRequest(new { message = "Username and password are required." });
            }

            // Find admin by username and validate password
            var admin = _context.Admins.SingleOrDefault(a => a.Username == adminCredentials.Username);

            if (admin == null || admin.Password != adminCredentials.Password)
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            return Ok(new { message = "Login successful!" });
        }

        // Check Login Endpoint
        [HttpGet("check")]
        public IActionResult CheckLogin([FromHeader] string username, [FromHeader] string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest(new { message = "Username and password are required in headers." });
            }

            // Find admin by username and password
            var admin = _context.Admins.SingleOrDefault(a => a.Username == username && a.Password == password);

            if (admin != null)
            {
                return Ok(new { message = "Admin check successful!" });
            }

            return Unauthorized(new { message = "Invalid credentials." });
        }
    }
}
