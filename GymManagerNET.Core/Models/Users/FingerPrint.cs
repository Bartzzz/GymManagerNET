using System.ComponentModel.DataAnnotations;

namespace GymManagerNET.Core.Models.Users;

public class FingerPrint
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(Int32.MaxValue)]
    public string Fingerprint { get; set; }

    public int UserId { get; set; }
    public Client User { get; set; }
}