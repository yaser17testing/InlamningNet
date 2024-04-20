using InlamningNet.Entity;

namespace InlamningNet.Repositories
{
    public interface ISubscriptionRepository
    {



        Task<List<Subscription>> GetAllAsync();
        Task<Subscription> CreateAsync(Subscription subscription);


        Task<Subscription?> GetByIdAsync(Guid id);

        Task<Subscription?> DeleteAsync(Guid id);

    }
}
