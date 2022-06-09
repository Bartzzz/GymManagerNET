using AutoMapper;
using GymManagerNET.Core.Models.DTOs.RoomsBooking;

namespace GymManagerNET.Core.Profiles
{
    public class RoomBookingProfile : Profile
    {
        public RoomBookingProfile()
        {
            CreateMap<Models.RoomBooking, RoomBookingDto>().ReverseMap();
        }
    }
}