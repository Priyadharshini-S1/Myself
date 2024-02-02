using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ClothingDapper.Controller
{
        [Route("api/[controller]")]
        [ApiController]
        public class LoginController : ControllerBase
        {
            private readonly IDbConnection _connection;

            public LoginController(IDbConnection connection)
            {
                _connection = connection;
            }

            [HttpPost("login")]
            [AllowAnonymous]
            public IActionResult Login([FromBody] Credentials credentials)
            {
                if (IsValidUser(credentials.UserName, credentials.Password))
                {
                    return Ok(new { Message = "Login successful" });
                }

                return Unauthorized(new { Message = "Invalid credentials" });
            }

        private bool IsValidUser(string username, string password)
        {
            return (username == "Priya" && password == "pri@123");
        }
    }
    
public class Credentials
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

}
