using GymManagerNET.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagerNET.Core.Services.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace GymManagerNET.Data.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Subscription> Add(Subscription subscription)
        {
            await _context.AddAsync(subscription);

            return await CommitAsync(subscription);
        }

        public async Task<Subscription> Delete(int id)
        {
            var subscription = await GetById(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
            }

            return await CommitAsync(subscription);
        }

        public async Task<Subscription> GetById(int id)
        {
            return await _context.Subscriptions?.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Subscription>> GetEntities(int id = 0)
        {
            return id == 0
                ? await _context.Subscriptions.ToListAsync()
                : await _context.Subscriptions.Where(x => x.UserId == id).ToListAsync();
        }

        public Task<Subscription> UpdateAsync(Subscription updatedSubscription)
        {
            _context.Subscriptions.Update(updatedSubscription);

            return CommitAsync(updatedSubscription);
        }

        private async Task<Subscription> CommitAsync(Subscription subscription)
        {
            var commit = await _context.SaveChangesAsync();

            return commit > 0 ? subscription : null;
        }
    }
}
