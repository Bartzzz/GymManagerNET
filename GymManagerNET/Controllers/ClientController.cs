using GymManagerNET.Core.DTOs.Users;
using GymManagerNET.Core.Enums;
using GymManagerNET.Core.Models.Users;
using GymManagerNET.Core.Services.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;

namespace GymManagerNET.Controllers;

[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
    Roles = $"{UserType.Manager}, {UserType.Reception}")]
[ApiController]
public class ClientController : Controller
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    
    [HttpGet("getAll")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _clientService.GetClients();

        if (users == null)
        {
            return NotFound();
        }

        return Ok(users);
    }


    [HttpGet("getClient")]
    public async Task<IActionResult> GetClient(int userId)
    {
        var client = await _clientService.GetClient(userId);

        if (client == null)
        {
            return NotFound();
        }

        return Ok(client);
    }

    [HttpPost("addClient")]
    public async Task<IActionResult> Addclient(ClientDto client)
    {
        var addedClient = await _clientService.AddClient(client);

        if (addedClient == null)
        {
            return NotFound();
        }

        return Ok(addedClient);
    }

    [HttpPut("updateClient")]
    public async Task<IActionResult> Updateclient(ClientDto client)
    {
        var updatedClient = await _clientService.UpdateClient(client);

        if (updatedClient == null)
        {
            return NotFound();
        }

        return Ok(updatedClient);
    }


    [HttpDelete("removeClient")]
    public async Task<IActionResult> RemoveClient(int clientId)
    {
        var removedClient = await _clientService.RemoveClient(clientId);

        if (removedClient == null)
        {
            return NotFound();
        }

        return Ok(removedClient);
    }

    [HttpPut("verifyEntrance")]
    public async Task<IActionResult> VerifyEntrance(int clientId)
    {
        var enteringClient = await _clientService.VerifyEntrance(clientId);

        if (enteringClient == null)
        {
            return NotFound();
        }

        return Ok(enteringClient);
    }

    [HttpPut("submitFingerprint")]
    public async Task<IActionResult> SubmitFingerPrint(FingerPrint fingerPrint)
    {
        var updatedClient = new ClientDto() { FingerPrint = new List<FingerPrint>(){ fingerPrint } };
      var result = await _clientService.UpdateClient(updatedClient);

        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}