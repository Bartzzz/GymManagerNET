using AutoMapper;
using GymManager.Core.DTOs.Subscriptions;
using GymManagerNET.Core.Models.DTOs.Subscriptions;

namespace GymManagerNET.Core.Profiles
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Models.Subscription, SubscriptionDto>().ReverseMap();
            CreateMap<Models.Subscription, ActiveSubscriptionDto>().ReverseMap();
            CreateMap<SubscriptionDto, ActiveSubscriptionDto>().ReverseMap();
        }
    }
}
