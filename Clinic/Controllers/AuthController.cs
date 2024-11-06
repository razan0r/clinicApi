using Clinic.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginModel loginModel)
    {
        var authCredentials = _configuration.GetSection("AuthCredential").Get<List<AuthCredential>>();

        foreach (var credential in authCredentials)
        {
            if (loginModel.UserName == credential.UserName && loginModel.Password == credential.Password)
            {
                var claims = new List<Claim>()
            {
                 new Claim(ClaimTypes.Name, credential.UserName),
                 new Claim(ClaimTypes.Role, credential.Role)
            };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                    audience: _configuration.GetValue<string>("Jwt:Audience"),
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(6),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
        }
        return Unauthorized();
    }
}
public class AuthCredential
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

}
