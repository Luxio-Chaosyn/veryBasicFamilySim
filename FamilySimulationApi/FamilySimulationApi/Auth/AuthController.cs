using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FamilySimulationApi.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IOptions<JwtSettings> jwtSettings) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (!UserService.ValidateUser(request.Username, request.Password))
            return Unauthorized("Invalid credentials");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Value.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: new[] { new Claim(ClaimTypes.Name, request.Username) },
            expires: DateTime.UtcNow.AddMinutes(jwtSettings.Value.ExpiryMinutes),
            signingCredentials: creds
        );

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }

    public record LoginRequest(string Username, string Password);
}
