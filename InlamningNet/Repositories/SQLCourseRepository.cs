using InlamningNet.Data;
using InlamningNet.Entity;
using Microsoft.EntityFrameworkCore;

namespace InlamningNet.Repositories
{
	public class SQLCourseRepository : ICourseRepository
	{
		private readonly NetDbcontext netDbcontext;

		public SQLCourseRepository(NetDbcontext netDbcontext)
		{
			this.netDbcontext = netDbcontext;
		}

		public async Task<Course> CreateAsync(Course course)
		{
			await netDbcontext.Courses.AddAsync(course);
			await netDbcontext.SaveChangesAsync();

			return course;
		}

		public async Task<List<Course>> GetAllAsync()
		{
			return await netDbcontext.Courses.ToListAsync();
		}

		public async Task<Course?> GetByIdAsync(Guid id)
		{
			return await netDbcontext.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
		}
	}


}
