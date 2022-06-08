using AutoMapper;
using GymManagerNET.Core.DTOs.Users;
using GymManagerNET.Core.Models.DTOs.Rooms;

namespace GymManagerNET.Core.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Models.FitnessRoom, RoomDto>().ReverseMap();
        }
    }
}