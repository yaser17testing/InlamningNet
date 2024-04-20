using InlamningNet.Entity;

namespace InlamningNet.Repositories
{
	public interface ICourseRepository
	{

		Task<List<Course>> GetAllAsync();
		Task<Course> CreateAsync(Course course);


		Task<Course?> GetByIdAsync(Guid id);
	}
}
