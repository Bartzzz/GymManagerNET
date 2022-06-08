using AutoMapper;
using GymManagerNET.Core.Models.DTOs.RoomsBooking;

namespace GymManagerNET.Core.Services.RoomBookings;

public class RoomBookingService : IRoomBookingService
{
    private readonly IRoomBookingRepository _roomBookingRepository;
    private readonly IActivityRepository _activityRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public RoomBookingService(IRoomBookingRepository roomBookingRepository, IActivityRepository activityRepository, IRoomRepository roomRepository, IMapper mapper)
    {
        _roomBookingRepository = roomBookingRepository;
        _activityRepository = activityRepository;
        _roomRepository = roomRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<RoomBookingDto>> GetRoomBookings()
    {
        var bookings = await _roomBookingRepository.GetEntities();
        var bookingDtos = bookings != null ? _mapper.Map<IEnumerable<RoomBookingDto>>(bookings) : null;

        if (bookingDtos == null)
        {
            return null;
        }

        foreach (var bookingDto in bookingDtos)
        {
            bookingDto.Activity = _activityRepository.GetById(bookingDto.ActivityId).Result;
        }

        return bookingDtos;
    }

    public async Task<RoomBookingDto> GetRoomBooking(int bookingId)
    {
        var booking = await _roomBookingRepository.GetById(bookingId);
        var bookingDto = booking != null ? _mapper.Map<RoomBookingDto>(booking) : null;

        if (bookingDto == null)
        {
            return null;
        }

        bookingDto.Activity = _activityRepository.GetById(bookingDto.ActivityId).Result;

        return bookingDto;
    }

    public async Task<RoomBookingDto> AddRoomBooking(RoomBookingDto booking)
    {
        var addedBooking = await _roomBookingRepository.Add(_mapper.Map<Models.RoomBooking>(booking));

        return addedBooking != null ? _mapper.Map<RoomBookingDto>(addedBooking) : null;
    }

    public async Task<RoomBookingDto> UpdateRoomBooking(RoomBookingDto booking)
    {
        var removedActivity = _roomBookingRepository.UpdateAsync(_mapper.Map<Models.RoomBooking>(booking));

        return removedActivity != null ? _mapper.Map<RoomBookingDto>(removedActivity) : null;
    }

    public async Task<RoomBookingDto> RemoveRoomBooking(int bookingId)
    {
        var removedActivity = await _roomBookingRepository.Delete(bookingId);

        return removedActivity != null ? _mapper.Map<RoomBookingDto>(removedActivity) : null;
    }
}