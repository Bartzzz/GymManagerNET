using GymManagerNET.Core.DTOs.Users;
using GymManagerNET.Core.Services.Client;
using GymManagerNET.Core.Services.Subscriptions;
using Microsoft.AspNetCore.Mvc;

namespace GymManagerNET.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FingerprintController : Controller
{
    private readonly IFingerPrintService _fingerPrintService;
    private readonly IClientService _clientService;
    private readonly ISubscriptionService _subscriptionService;

    public FingerprintController(IFingerPrintService fingerPrintService, IClientService clientService,
        ISubscriptionService subscriptionService)
    {
        _fingerPrintService = fingerPrintService;
        _clientService = clientService;
        _subscriptionService = subscriptionService;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetFingerprints()
    {
        var fingerprints = await _fingerPrintService.GetFingerPrints();

        if (fingerprints == null)
        {
            return NotFound();
        }

        return Ok(fingerprints);
    }

    [HttpPost("addFingerprint")]
    public async Task<IActionResult> Addclient(FingerPrintDto fingerPrint)
    {
        var addedFingerprint = await _fingerPrintService.SaveFingerPrint(fingerPrint);

        if (addedFingerprint == null)
        {
            return NotFound();
        }

        return Ok(addedFingerprint);
    }

    [HttpPost("verifyUser")]
    public async Task<IActionResult> VerifyUser(int userId)
    {
        var subscriptions = await _subscriptionService.GetSubscriptions(userId);

        if (subscriptions == null)
        {
            return NotFound();
        }

        var activeSubscription = _subscriptionService.ValidateSubscriptionAsync(subscriptions);
        return Ok(activeSubscription);
    }
}
