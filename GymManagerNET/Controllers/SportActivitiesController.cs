using GymManagerNET.Core.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManagerNET.Controllers
{
    [Route("api/[controller]")]
    [Authorize(
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = UserType.Manager)]
    [ApiController]
    public class SportActivitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
