using AutoMapper;
using GymManagerNET.Core.DTOs.Users;
using GymManagerNET.Core.Models.DTOs.Activities;

namespace GymManagerNET.Core.Profiles
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<Models.Activity, ActivityDto>().ReverseMap();
        }
    }
}