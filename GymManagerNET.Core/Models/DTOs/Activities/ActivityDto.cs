namespace GymManagerNET.Core.Models.DTOs.Activities;

public class ActivityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MaximumAttendants { get; set; }
    public List<RoomBooking> Bookings { get; set; }
}