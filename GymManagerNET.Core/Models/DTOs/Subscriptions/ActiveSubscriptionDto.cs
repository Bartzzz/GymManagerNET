using GymManagerNET.Core.Models.DTOs.Subscriptions;

namespace GymManager.Core.DTOs.Subscriptions
{
    public class ActiveSubscriptionDto : SubscriptionDto
    {
        public bool IsActive { get; set; }
    }
}
