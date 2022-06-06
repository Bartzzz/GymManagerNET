using GymManagerNET.Core.Enums;
using GymManagerNET.Core.Models.DTOs.Subscriptions;
using GymManagerNET.Core.Services.SubscriptionService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManagerNET.Controllers;

[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
    Roles = $"{UserType.Manager}, {UserType.Reception}")]
[ApiController]
public class SubscriptionController : Controller
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetSubscriptions()
    {
        var subscriptions = await _subscriptionService.GetSubscriptions();

        if (subscriptions == null)
        {
            return NotFound();
        }

        return Ok(subscriptions);

    }

    [HttpGet("validateUserSubscription")]
    public async Task<IActionResult> ValidateUserSubscription(int userId)
    {
        var subscription = _subscriptionService.GetUserSubscription(userId);

        if (subscription == null)
        {
            return NotFound();
        }

        return Ok(subscription);
    }

    [HttpPost("addSubscription")]
    public async Task<IActionResult> AddSubscription(SubscriptionDto subscription)
    {
        var addedSubscription = _subscriptionService.AddSubscription(subscription);

        if (addedSubscription == null)
        {
            return NotFound();
        }

        return Ok(addedSubscription);
    }

    [HttpPut("updateSubscription")]
    public async Task<IActionResult> UpdateSubscription(SubscriptionDto subscription)
    {
        var updatedSubscription = _subscriptionService.UpdateSubscription(subscription);

        if (updatedSubscription == null)
        {
            return NotFound();
        }

        return Ok(updatedSubscription);
    }

    [HttpDelete("removeSubscription")]
    public async Task<IActionResult> RemoveSubscription(int subscriptionId)
    {
        var removedSubscription = _subscriptionService.RemoveSubscriptionAsync(subscriptionId);

        if (removedSubscription == null)
        {
            return NotFound();
        }

        return Ok(removedSubscription);
    }
}
