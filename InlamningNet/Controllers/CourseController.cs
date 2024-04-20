using InlamningNet.Data;
using InlamningNet.DTO;
using InlamningNet.Entity;
using InlamningNet.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InlamningNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	
    public class CourseController : ControllerBase
    {
		private readonly NetDbcontext netDbcontext;
		private readonly ICourseRepository courseRepository;

		public CourseController(NetDbcontext netDbcontext, ICourseRepository courseRepository)
        {
			this.netDbcontext = netDbcontext;
			this.courseRepository = courseRepository;
		}




		[HttpGet]
		public async Task<IActionResult> GetAll()
		{



			var coursesDomain = await courseRepository.GetAllAsync();

			var coursesDto = new List<CourseDto>();
			foreach (var courseDomain in coursesDomain)
			{

				coursesDto.Add(new CourseDto()
				{
					CourseId = courseDomain.CourseId,
					Title = courseDomain.Title,
					Description = courseDomain.Description,
					Price = courseDomain.Price,
					Duration = courseDomain.Duration,

				});

			}


			return Ok(coursesDto);


		}


		[HttpGet]
		[Route("{id:Guid}")]

		public async Task<IActionResult> GetById([FromRoute] Guid id)
		{
			var courseDomain = await courseRepository.GetByIdAsync(id);

			if (courseDomain == null)
			{
				return NotFound();
			}
			var courseDto = new CourseDto
			{
				CourseId = courseDomain.CourseId,
				Title = courseDomain.Title,
				Description = courseDomain.Description,
				Price = courseDomain.Price,
				Duration = courseDomain.Duration,
			};
			return Ok(courseDto);

		}







		[HttpPost]

		public async Task<IActionResult> Create([FromBody] AddCourseRequestDto addCourseRequestDto)
		{
			var courseDomainModel = new Course
			{
				Title = addCourseRequestDto.Title,
				Description = addCourseRequestDto.Description,
				Price = addCourseRequestDto.Price,
				Duration = addCourseRequestDto.Duration,
			};




			courseDomainModel = await courseRepository.CreateAsync(courseDomainModel);


			var courseDto = new CourseDto
			{
				CourseId = courseDomainModel.CourseId,
				Title = courseDomainModel.Title,
				Description = courseDomainModel.Description,
				Price = courseDomainModel.Price,
				Duration = courseDomainModel.Duration,

			};
			return CreatedAtAction(nameof(GetById), new { id = courseDto.CourseId }, courseDto);
		}






	}
}
