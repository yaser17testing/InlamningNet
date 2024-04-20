using Net.UI.Models.Entity;

namespace Net.UI.Repository
{
	public interface IAdressRepository
	{



		Task<Adress?> GetAsync(Guid id);
		Task<Adress?> AddAsync(Adress adress);
		Task<Adress?> UpdateAsync(Guid id, Adress adress);

		Task<Adress?> GetIdAsync(Guid id);
	}
}
