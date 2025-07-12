using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPIJWTDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        [HttpGet("generatetoken")]
        public IActionResult GenerateToken()
        {
            // Sample user data - in real app, this would come from login validation
            int userId = 1;
            string userRole = "Admin";

            var token = GenerateJSONWebToken(userId, userRole);

            return Ok(new { token = token });
        }

        [HttpGet("generatetoken-poc")]
        public IActionResult GenerateTokenPOC()
        {
            // Generate token with POC role for testing
            int userId = 2;
            string userRole = "POC";

            var token = GenerateJSONWebToken(userId, userRole);

            return Ok(new { token = token });
        }

        private string GenerateJSONWebToken(int userId, string userRole)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecretkeyforjwtauthentication2024"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
                new Claim("UserId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                        issuer: "mySystem",
                        audience: "myUsers",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(10), // Initially 10 minutes
                        signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
