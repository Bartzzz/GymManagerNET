using AutoMapper;
using GymManagerNET.Core.DTOs.Users;

namespace GymManagerNET.Core.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Models.Users.Client, ClientDto>().ReverseMap();
        }
    }
}