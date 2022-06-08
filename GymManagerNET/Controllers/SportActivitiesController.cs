using GymManagerNET.Core.Enums;
using GymManagerNET.Core.Models.DTOs.Activities;
using GymManagerNET.Core.Services.RoomBookings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManagerNET.Controllers;

[Route("api/[controller]")]
[Authorize(
    AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
    Roles = UserType.Manager)]
[ApiController]
public class SportActivitiesController : Controller
{

    private readonly IActivityService _activityService;

    public SportActivitiesController(IActivityService activityService)
    {
        _activityService = activityService;
    }
    [HttpGet("getAll")]
    public async Task<IActionResult> GetActivities()
    {
        var activities = await _activityService.GetActivities();

        if (activities == null)
        {
            return NotFound();
        }

        return Ok(activities);
    }

    [HttpGet("getActivity")]
    public async Task<IActionResult> GetActivity(int activityId)
    {
        var client = await _activityService.GetActivity(activityId);

        if (client == null)
        {
            return NotFound();
        }

        return Ok(client);
    }

    [HttpPost("addActivity")]
    public async Task<IActionResult> Addclient(ActivityDto activity)
    {
        var addedClient = await _activityService.AddActivity(activity);

        if (addedClient == null)
        {
            return NotFound();
        }

        return Ok(addedClient);
    }

    [HttpPut("updateActivity")]
    public async Task<IActionResult> UpdateActivity(ActivityDto Activity)
    {
        var updatedClient = await _activityService.UpdateActivity(Activity);

        if (updatedClient == null)
        {
            return NotFound();
        }

        return Ok(updatedClient);
    }


    [HttpDelete("removeActivity")]
    public async Task<IActionResult> RemoveActivity(int ActivityId)
    {
        var removedClient = await _activityService.RemoveActivity(ActivityId);

        if (removedClient == null)
        {
            return NotFound();
        }

        return Ok(removedClient);
    }
}
