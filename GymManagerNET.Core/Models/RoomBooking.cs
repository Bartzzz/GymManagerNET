using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace GymManagerNET.Core.Models;

public class RoomBooking
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int RoomId { get; set; }

    public FitnessRoom Room { get; set; }

    [Required]
    public string DayOfWeek { get; set; }
    [Required]
    public string StartTime { get; set; }
    [Required]
    public string Duration { get; set; }
    public int ActivityId { get; set; }
    public Activity Activity { get; set; }
}