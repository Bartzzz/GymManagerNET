using GymManagerNET.Core.Models.DTOs.Rooms;

namespace GymManagerNET.Core.Services.RoomBookings;

public interface IRoomService
{
    Task<RoomDto?> GetRooms();
    Task<RoomDto?> GetRoom(int roomId);
    Task<RoomDto?> AddRoom(RoomDto room);
    Task<RoomDto?> UpdateRoom(object room);
    Task<RoomDto?> RemoveRoom(object roomId);
}