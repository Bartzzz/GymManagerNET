using GymManagerNET.Core.DTOs.Users;
using GymManagerNET.Core.Models.Users;
using AutoMapper;

namespace GymManagerNET.Core.Profiles;

public class FingerPrintProfile : Profile
{
    public FingerPrintProfile()
    {
        CreateMap<FingerPrint, FingerPrintDto>().ReverseMap();
    }
}