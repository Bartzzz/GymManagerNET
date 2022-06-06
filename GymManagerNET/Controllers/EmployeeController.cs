using GymManagerNET.Core.Enums;
using GymManagerNET.Core.Models.Users;
using GymManagerNET.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymManagerNET.Controllers;

[Route("api/[controller]")]
[Authorize(
    AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
    Roles = UserType.Manager)]
[ApiController]
public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _config;
    private readonly UserManager<DefaultEmployee> _userManager;

    public EmployeeController(ApplicationDbContext context, IConfiguration config,
        UserManager<DefaultEmployee> userManager)
    {
        _context = context;
        _config = config;
        _userManager = userManager;
    }

    [HttpPost("addEmployee")]
    public async Task<IActionResult> AddEmployee(DefaultEmployee employee)
    {
        DefaultEmployee user = await _userManager.FindByEmailAsync(employee.Email);
        if (user == null)
        {
            user = new DefaultEmployee()
            {
                Email = employee.Email,
                UserName = employee.Email,
                Name = employee.Name,
                Surname = employee.Surname,
                UserType = employee.UserType,
                PhoneNumber = employee.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, "P@ssw0rd!1");
            if (result != IdentityResult.Success)
            {
                return BadRequest("Failed to add user");
            }

            return Ok($"Employee {user.Email} added successfully");
        }

        return BadRequest($"Employee {user.Email} already exist in the database");
    }

    [HttpPost("changeEmployeeRole")]

    public async Task<IActionResult> ChangeEmployeeRole(string email, string role)
    {
        DefaultEmployee user = await _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            user.UserType = role;

            var result = await _userManager.UpdateAsync(user);

            if (result != IdentityResult.Success)
            {
                return BadRequest("Failed to change role");
            }

            return Ok($"Employee {user.Email} role changed successfully");
        }

        return BadRequest($"Employee {user.Email} does not exist in the database");
    }

    [HttpDelete("removeEmployee")]
    public async Task<IActionResult> RemoveEmployee(DefaultEmployee employee)
    {
        DefaultEmployee user = await _userManager.FindByEmailAsync(employee.Email);
        if (user != null)
        {

            var result = await _userManager.DeleteAsync(user);
            if (result != IdentityResult.Success)
            {
                return BadRequest("Failed to remove user");
            }

            return Ok($"Employee {user.Email} removed successfully");
        }

        return BadRequest($"Employee {user.Email} doesn't exist in the database");
    }
}



