using System.ComponentModel.DataAnnotations;
using GymManagerNET.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace GymManagerNET.Core.Models.Users;

public class Trainer : DefaultEmployee
{
    public int ClientID;
    public List<Client> ManagedClients { get; set; } = new List<Client>();
}