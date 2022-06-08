using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GymManagerNET.Core.DTOs.Users;
using GymManagerNET.Core.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GymManagerNET.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : Controller
{

    private readonly SignInManager<DefaultEmployee> _signInManager;
    private readonly UserManager<DefaultEmployee> _userManager;
    private readonly IConfiguration _config;

    public AuthenticationController(SignInManager<DefaultEmployee> signInManager, UserManager<DefaultEmployee> userManager, IConfiguration config)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _config = config;
    }

    [HttpPost("createToken")]
    public async Task<IActionResult> CreateToken([FromBody] EmployeeDto employee)
    {
        if (!ModelState.IsValid) return BadRequest();
        var user = await _userManager.FindByNameAsync(employee.Username);
        if (user != null)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, employee.Password, false);

            if (result.Succeeded)
            {
                // Create the Token
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    new Claim(ClaimTypes.Role, user.UserType)
                };
                    

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _config["Tokens:Issuer"],
                    _config["Tokens:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: creds);

                var results = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                };

                return Created("", results);
            }
        }

        return BadRequest();
    }
}

