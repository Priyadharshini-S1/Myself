using Logistics_Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistics_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginRepocs _userService;
        public LoginController(LoginRepocs userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromQuery] string username, [FromQuery] string password)
        {
            var user = _userService.Authenticate(username,
                password);
            {
                if (user == null)
                {
                    return BadRequest(new
                    {
                        message = "username or password is invalid"
                    });
                }
                return Ok(user);
            }
        }
    }
}
