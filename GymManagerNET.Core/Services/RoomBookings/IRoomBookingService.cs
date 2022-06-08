using GymManagerNET.Core.Models.DTOs.RoomsBooking;

namespace GymManagerNET.Core.Services.RoomBookings;

public interface IRoomBookingService
{
    Task<IEnumerable<RoomBookingDto>> GetRoomBookings();
    Task<RoomBookingDto> GetRoomBooking(int activityId);
    Task<RoomBookingDto> AddRoomBooking(RoomBookingDto activity);
    Task<RoomBookingDto> UpdateRoomBooking(RoomBookingDto activity);
    Task<RoomBookingDto> RemoveRoomBooking(int activityId);
}