using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net.UI.Data;
using Net.UI.Models;
using Net.UI.Models.DTO;
using Net.UI.Models.Entity;
using Net.UI.Models.ViewModels;
using Net.UI.Repository;
using System.Security.Claims;

namespace Net.UI.Controllers
{



	[Authorize(Roles = "User")]
	public class CourseController : Controller
	{
		private readonly IHttpClientFactory httpClientFactory;
		private readonly NetDbContext netDbContext;
		private readonly IOrderRepository orderRepository;

		public CourseController(IHttpClientFactory httpClientFactory, NetDbContext netDbContext, IOrderRepository orderRepository)
		{
			this.httpClientFactory = httpClientFactory;
			this.netDbContext = netDbContext;
			this.orderRepository = orderRepository;
		}




		[HttpGet]

		public async Task<IActionResult> Index()
		{

			List<CourseDto> response = new List<CourseDto>();

			try
			{
				var client = httpClientFactory.CreateClient();


				var httpResponseMessage = await client.GetAsync("https://localhost:7233/api/Course");

				httpResponseMessage.EnsureSuccessStatusCode();

				response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<CourseDto>>());



			}
			catch (Exception ex)
			{

				//Log the excpetion
			}

			return View(response);
		}


		[HttpGet]

		public async Task<IActionResult> GetCourse(Guid id)
		{

			var client = httpClientFactory.CreateClient();

			var response = await client.GetFromJsonAsync<CourseDto>($"https://localhost:7233/api/Course/{id.ToString()}");


			if (response is not null)
			{

				return View(response);
			}

			return View(null);
		}


		public IActionResult BuyCourse()
		{

			return View();
		}



		[HttpGet]
		public async Task<IActionResult> BuyCourse(Guid id)
		{

			var client = httpClientFactory.CreateClient();

			var response = await client.GetFromJsonAsync<CourseDto>($"https://localhost:7233/api/Course/{id.ToString()}");


			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Hämtar användar-ID

			var appUser = await netDbContext.AppUsers.FirstOrDefaultAsync(u => u.IdentityUserId == userId);


			var orderId = await netDbContext.Orders.FirstOrDefaultAsync(o => o.UserId == appUser.Id);

			string courseId = response.ToString();

			




			//Exakt samma kod fast, den som används kör från Repository.

			//var existingOrder = await netDbContext.Orders.FirstOrDefaultAsync(o => o.UserId == appUser.Id && o.CourseId == response.CourseId.ToString());


			var existingOrder = await orderRepository.GetOneIdCourseId(appUser.Id,response.CourseId.ToString());



			if (existingOrder != null)
			{


				return View("Index");

			}


			var newOrder = new Order
			{
				UserId = appUser.Id,
				CourseId = response.CourseId.ToString(),
			};

		

				var orderbuy = await netDbContext.Orders.AddAsync(newOrder);

await netDbContext.SaveChangesAsync();

				return View("Index");

			



			


			

			

			

			

			return View("Index");


		}



		[HttpGet]
		public async Task<IActionResult> GetOrderList()
		{

			var client = httpClientFactory.CreateClient();

			//var response = await client.GetFromJsonAsync<CourseDto>($"https://localhost:7233/api/Course/{id.ToString()}");


			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Hämtar användar-ID

			var appUser = await netDbContext.AppUsers.FirstOrDefaultAsync(u => u.IdentityUserId == userId);

			if (appUser == null)
			{

				return NotFound();


			}




			var orders = await netDbContext.Orders
							.Where(o => o.UserId == appUser.Id)
							.ToListAsync();

            var courseIds = orders.Select(o => o.CourseId).Distinct();
           


            var orderViewModels = orders.Select(o => new OrderViewModel
			{
				
				CourseId = o.CourseId,
				PurchaseDate = o.PurchaseDate,
				
				

			}).ToList();

			
			return View(orderViewModels);





		}

        }
}
