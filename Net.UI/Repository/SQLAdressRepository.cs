using Microsoft.EntityFrameworkCore;
using Net.UI.Data;
using Net.UI.Models.Entity;

namespace Net.UI.Repository
{
	public class SQLAdressRepository : IAdressRepository
	{
		private readonly NetDbContext netDbContext;

		public SQLAdressRepository(NetDbContext netDbContext)
        {
			this.netDbContext = netDbContext;
		}
        public async Task<Adress?> AddAsync(Adress adress)
		{
			await netDbContext.Adresses.AddAsync(adress);
			await netDbContext.SaveChangesAsync();
			return adress;
		}

		public async Task<Adress?> GetIdAsync(Guid id)
		{
			return await netDbContext.Adresses.FirstOrDefaultAsync(x => x.AppUserId == id);
		}

		public async Task<Adress?> GetAsync(Guid id)
		{
			return await netDbContext.Adresses.FirstOrDefaultAsync(x => x.Id == id);
		}


		


		public async Task<Adress?> UpdateAsync(Guid id, Adress adress)
		{
			var existingAdress = await netDbContext.Adresses.FirstOrDefaultAsync(x => x.Id == id);

			if (existingAdress == null)
			{

				return null;
			}
			existingAdress.AdressOne = adress.AdressOne;
			existingAdress.AdressTwo = adress.AdressTwo;
			existingAdress.City = adress.City;
			existingAdress.PostalCode = adress.PostalCode;

			await netDbContext.SaveChangesAsync();
			return existingAdress;
		}
	}
}
