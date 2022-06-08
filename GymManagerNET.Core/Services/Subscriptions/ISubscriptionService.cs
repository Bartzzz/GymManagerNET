using GymManager.Core.DTOs.Subscriptions;
using GymManagerNET.Core.Models.DTOs.Subscriptions;

namespace GymManagerNET.Core.Services.Subscriptions;

public interface ISubscriptionService
{
    Task<IEnumerable<SubscriptionDto>> GetSubscriptions(int id = 0);
    Task<ActiveSubscriptionDto> GetUserSubscription(int userId);
    Task<SubscriptionDto> AddSubscription(SubscriptionDto subscription);
    Task<SubscriptionDto> UpdateSubscription(SubscriptionDto subscription);
    Task<SubscriptionDto> RemoveSubscriptionAsync(int subscriptionId);
    Task<ActiveSubscriptionDto> ValidateSubscriptionAsync(IEnumerable<SubscriptionDto> subscriptions);
}