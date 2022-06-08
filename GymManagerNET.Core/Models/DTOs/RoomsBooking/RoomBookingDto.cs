namespace GymManagerNET.Core.Models.DTOs.RoomsBooking;

public class RoomBookingDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string DayOfWeek { get; set; }
    public string StartTime { get; set; }
    public string Duration { get; set; }
    public int ActivityId { get; set; }
    public Activity Activity { get; set; }
}