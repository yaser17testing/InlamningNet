using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Net.UI.Data;
using Net.UI.Models;
using Net.UI.Models.DTO;
using Net.UI.Models.Entity;
using Net.UI.Repository;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Claims;

namespace Net.UI.Controllers
{

	[Authorize(Roles = "User")]

	public class AppUserController : Controller



	{
		private readonly NetDbContext netDbContext;
		private readonly IAdressRepository adressRepository;
        private readonly IConfiguration configuration;
		private readonly ImageRepository imageRepository;

		public AppUserController(NetDbContext netDbContext, IAdressRepository adressRepository,IConfiguration configuration,ImageRepository imageRepository)
		{
			this.netDbContext = netDbContext;
			this.adressRepository = adressRepository;
            this.configuration = configuration;
			this.imageRepository = imageRepository;
		}


		public IActionResult Index()
		{
			return View();
		}




		public async Task<IActionResult> SavedCourse()
		{




			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Hämtar användar-ID

			var appUser = await netDbContext.AppUsers.FirstOrDefaultAsync(u => u.IdentityUserId == userId);


			var OrderId = await netDbContext.Orders.FirstOrDefaultAsync(o => o.UserId == appUser.Id);





			return View();
		}




		[HttpPost]
		public async Task<IActionResult> EditAdress(EditDto editDto)
		{



			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Hämtar användar-ID






			var appUser = await netDbContext.AppUsers.FirstOrDefaultAsync(u => u.IdentityUserId == userId);


			if (appUser == null)
			{
				return NotFound("User not found.");
			}



			Guid appUserId = appUser.Id;



			var adress = await adressRepository.GetIdAsync(appUserId);



			if (adress == null)
			{
				adress = new Adress
				{
					AppUserId = appUser.Id,
					AdressOne = editDto.AdressOne,
					AdressTwo = editDto.AdressTwo,
					City = editDto.City,
					PostalCode = editDto.PostalCode,
				};

				await netDbContext.Adresses.AddAsync(adress);
			}
			else
			{


				adress.AdressOne = editDto.AdressOne;
				adress.AdressTwo = editDto.AdressTwo;
				adress.City = editDto.City;
				adress.PostalCode = editDto.PostalCode;



				//var result = await adressRepository.UpdateAsync(appUserId);



			}

			await netDbContext.SaveChangesAsync();


			return RedirectToAction("EditUser");

		}















		[HttpGet]

		public async Task<IActionResult> EditUser()
		{


			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Hämtar användar-ID 





			var appUser = await netDbContext.AppUsers.FirstOrDefaultAsync(u => u.IdentityUserId == userId); // App user Id i string.

			Guid appUserId = appUser.Id;


			if (appUser == null)
			{

				return NotFound();

			}
			var userEmail = User.FindFirstValue(ClaimTypes.Email); // Hämtar EmailAdress

			//Testing


			var address = await adressRepository.GetIdAsync(appUser.Id) ?? new Adress();

			var editDto = new EditDto
			{
				Email = userEmail,
				Name = appUser.Name,
				LastName = appUser.LastName,
				ProfilImage = appUser.ProfilImage,
				Bio = appUser.Bio,


				AdressOne = address.AdressOne,
				AdressTwo = address.AdressTwo,
				PostalCode = address.PostalCode,
				City = address.City,



			};

			return View(editDto);

		}








		[HttpPost]

		public async Task<IActionResult> EditUser(EditDto editDto)
		{





			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Hämtar användar-ID




			var userEmail = User.FindFirstValue(ClaimTypes.Email); // Hämtar EmailAdress

			var appUser = await netDbContext.AppUsers.FirstOrDefaultAsync(u => u.IdentityUserId == userId);








			if (appUser == null)
			{


				return NotFound();

			}


			//Test härifrån




			editDto.Email = userEmail;
			appUser.Name = editDto.Name;
			appUser.LastName = editDto.LastName;
			appUser.Bio = editDto.Bio;
			




			//Test 


			await netDbContext.SaveChangesAsync();


			return RedirectToAction("EditUser");
		}






		





		[HttpPost]
		public async Task<IActionResult> UploadImage(IFormFile file)
		{




			var result = await imageRepository.UploadUserProfilImageAsync(User, file);






			/*
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


			
				var appUser = await netDbContext.AppUsers.FirstOrDefaultAsync(u => u.IdentityUserId == userId);

			if (appUser != null)
			{


			var model = new EditDto { ProfilImage = appUser?.ProfilImage };

				return View("EditUser", model);  // Se till att "EditUser" är namnet på din vy


			}
			*/

			return RedirectToAction("EditUser");



			


			


		}









	}
}
