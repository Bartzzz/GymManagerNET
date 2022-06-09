using AutoMapper;
using GymManagerNET.Core.Models.DTOs.Rooms;

namespace GymManagerNET.Core.Services.RoomBookings;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public RoomService(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public Task<RoomDto?> AddRoom(RoomDto room)
    {
        throw new NotImplementedException();
    }

    public async Task<RoomDto?> GetRoom(int roomId)
    {
        var roomEntities = await _roomRepository.GetById(roomId);
        return roomEntities != null
            ? _mapper.Map<RoomDto>(roomEntities)
            : null;
    }

    public async Task<IEnumerable<RoomDto>?> GetRooms()
    {
        var roomEntities = await _roomRepository.GetEntities();
        return roomEntities != null
            ? _mapper.Map<IEnumerable<RoomDto>>(roomEntities).ToList()
            : null;
    }

    public Task<RoomDto?> RemoveRoom(object roomId)
    {
        throw new NotImplementedException();
    }

    public Task<RoomDto?> UpdateRoom(object room)
    {
        throw new NotImplementedException();
    }
}