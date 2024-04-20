using Azure;
using Net.UI.Models.Entity;

namespace Net.UI.Repository
{
    public interface IOrderRepository
    {

        Task<IEnumerable<Order>> GetAllAsync();


        Task<Order?>GetOneIdCourseId(Guid id,string course);
        Task<Order?> GetAsync(Guid id);
        Task<Order> AddAsync(Order order);
        Task<Order?> UpdateAsync(Order order);

        Task<Order?> DeleteAsync(Guid id);



    }
}
