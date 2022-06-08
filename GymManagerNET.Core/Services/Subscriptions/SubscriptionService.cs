using AutoMapper;
using GymManager.Core.DTOs.Subscriptions;
using GymManagerNET.Core.Enums;
using GymManagerNET.Core.Models;
using GymManagerNET.Core.Models.DTOs.Subscriptions;

namespace GymManagerNET.Core.Services.Subscriptions;

        public class SubscriptionService : ISubscriptionService
        {
            private readonly ISubscriptionRepository _subscriptionRepository;
            private readonly IMapper _mapper;

            public SubscriptionService(ISubscriptionRepository subscriptionRepository, IMapper mapper)
            {
                _subscriptionRepository = subscriptionRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<SubscriptionDto>> GetSubscriptions(int id = 0)
            {
                var subscriptionEntities = await _subscriptionRepository.GetEntities(id);
                return subscriptionEntities != null
                    ? _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptionEntities)
                    : null;
            }

            public async Task<ActiveSubscriptionDto> GetUserSubscription(int id)
            {
                var userSubscriptions = await _subscriptionRepository.GetEntities(id);

                if (userSubscriptions == null || !userSubscriptions.Any())
                {
                    return null;
                }

                var activeSubscription =
                    await ValidateSubscriptionAsync((_mapper.Map<IEnumerable<SubscriptionDto>>(userSubscriptions)));
                return activeSubscription;
            }

            public async Task<SubscriptionDto> AddSubscription(SubscriptionDto subscription)
            {
                var addedSubscription = await _subscriptionRepository.Add(_mapper.Map<Subscription>(subscription));

                return addedSubscription != null ? _mapper.Map<SubscriptionDto>(addedSubscription) : null;
            }

            public async Task<SubscriptionDto> UpdateSubscription(SubscriptionDto subscription)
            {
                var updatedSubscription =
                    await _subscriptionRepository.UpdateAsync(_mapper.Map<Subscription>(subscription));

                return updatedSubscription != null ? _mapper.Map<SubscriptionDto>(updatedSubscription) : null;
            }

            public async Task<SubscriptionDto> RemoveSubscriptionAsync(int subscriptionId)
            {
                var updatedSubscription = await _subscriptionRepository.Delete(subscriptionId);

                return updatedSubscription != null ? _mapper.Map<SubscriptionDto>(updatedSubscription) : null;
            }


            //obczaić potem
            public Task<ActiveSubscriptionDto> ValidateSubscriptionAsync(IEnumerable<SubscriptionDto> userSubscriptions)
            {
                var subscription = userSubscriptions.OrderByDescending(x => x.StartDate).FirstOrDefault();
                var activeSubscription = _mapper.Map<ActiveSubscriptionDto>(subscription);

                if (activeSubscription.StartDate > DateTime.Now.AddMonths(-1) &&
                    (activeSubscription.SubscriptionType == SubscriptionType.Monthly ||
                     activeSubscription.EntrancesLeft > 0))
                {
                    activeSubscription.IsActive = true;
                }

                return Task.FromResult(activeSubscription);

            }
        }


