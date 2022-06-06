using System.ComponentModel.DataAnnotations;
using GymManagerNET.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace GymManagerNET.Core.Models.Users;

public class DefaultEmployee : IdentityUser
{
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(100)]
    public string Surname { get; set; }

    [Required]
    public string UserType { get; set; }
}