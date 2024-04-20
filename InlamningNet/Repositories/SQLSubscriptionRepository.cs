using InlamningNet.Data;
using InlamningNet.Entity;
using Microsoft.EntityFrameworkCore;

namespace InlamningNet.Repositories
{
    public class SQLSubscriptionRepository : ISubscriptionRepository
    {
        private readonly NetDbcontext netDbcontext;

        public SQLSubscriptionRepository(NetDbcontext netDbcontext)
        {
            this.netDbcontext = netDbcontext;
        }

        public async Task<Subscription> CreateAsync(Subscription subscription)
        {
            await netDbcontext.Subscriptions.AddAsync(subscription);
            await netDbcontext.SaveChangesAsync();

            return subscription;
        }

        public async Task<Subscription?> DeleteAsync(Guid id)
        {
            var existingUser = await netDbcontext.Subscriptions.FirstOrDefaultAsync(x => x.SubscriptionId == id);
            if (existingUser == null)
            {

                return null;
            }
            netDbcontext.Subscriptions.Remove(existingUser);

            await netDbcontext.SaveChangesAsync();

            return existingUser;
        }

        public async Task<List<Subscription>> GetAllAsync()
        {
            return await netDbcontext.Subscriptions.ToListAsync();
        }

        public async Task<Subscription?> GetByIdAsync(Guid id)
        {
            return await netDbcontext.Subscriptions.FirstOrDefaultAsync(x => x.SubscriptionId == id);
        }
    }
}
