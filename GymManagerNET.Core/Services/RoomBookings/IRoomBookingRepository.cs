using GymManagerNET.Core.Models;
using GymManagerNET.Core.Services.Base;

namespace GymManagerNET.Core.Services.RoomBookings;

public interface IRoomBookingRepository: IBaseRepository<Models.RoomBooking>
{
    public Task<IEnumerable<Models.RoomBooking>> GetEntitiesByRoomId(int id = 0);

    public Task<IEnumerable<Models.RoomBooking>> GetEntitiesByActivityId(int id = 0);
}