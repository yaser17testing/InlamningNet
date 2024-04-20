using Azure;
using Microsoft.EntityFrameworkCore;
using Net.UI.Data;
using Net.UI.Models.Entity;

namespace Net.UI.Repository
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly NetDbContext netDbContext;

        public SQLOrderRepository(NetDbContext netDbContext)
        {
            this.netDbContext = netDbContext;
        }

        public async Task<Order> AddAsync(Order order)
        {
            await netDbContext.Orders.AddAsync(order);
            await netDbContext.SaveChangesAsync();
            return order;
        }

        public Task<Order?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await netDbContext.Orders.ToListAsync();
        }

        public async Task<Order?> GetAsync(Guid id)
        {
            return await netDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

		public async Task<Order?> GetOneIdCourseId(Guid id, string course)
		{
			return await netDbContext.Orders.FirstOrDefaultAsync(x => x.UserId == id && x.CourseId == course);
		}

		public Task<Order?> UpdateAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
