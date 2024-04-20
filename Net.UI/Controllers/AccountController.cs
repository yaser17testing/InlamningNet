using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net.UI.Data;
using Net.UI.Models.Entity;
using Net.UI.Models.ViewModels;
using Net.UI.Repository;

namespace Net.UI.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly NetDbContext netDbContext;
		private readonly SignInManager<IdentityUser> signInManager;
		private readonly IAdressRepository adressRepository;

		public AccountController(UserManager<IdentityUser> userManager, NetDbContext netDbContext, SignInManager<IdentityUser> signInManager,IAdressRepository adressRepository)
		{
			this.userManager = userManager;
			this.netDbContext = netDbContext;
			this.signInManager = signInManager;
			this.adressRepository = adressRepository;
		}




		//var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Hämtar användar-ID
		//var userInfo = await _dbContext.AppUsers.FindAsync(userId); // Använd ID för att hämta användarinformation från databasen



		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}



		[HttpPost]


		public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		{

			var identityUser = new IdentityUser
			{
				UserName = registerViewModel.Username,
				Email = registerViewModel.Email
			};
			var identityResult = await userManager.CreateAsync(identityUser, registerViewModel.Password);
			if (identityResult.Succeeded)
			{
				var appUser = new AppUser { IdentityUserId = identityUser.Id, Name = registerViewModel.Name, LastName = registerViewModel.LastName };



				netDbContext.AppUsers.Add(appUser);
				await netDbContext.SaveChangesAsync();


				
			

				//assign this user the "User" role
				var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "User");

				if (roleIdentityResult.Succeeded)
				{
					//Show sucess notification

					return RedirectToAction("Register");

				}
			}
			//Show error notification

			return View();




		}



		[HttpGet]

		public IActionResult Login(string ReturnUrl)
		{


			var model = new LoginViewModel
			{
				ReturnUrl = ReturnUrl,
			};
			return View(model);

		}


		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{


			var signInResult = await signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, false);


			if (signInResult != null && signInResult.Succeeded)
			{

				if (!string.IsNullOrWhiteSpace(loginViewModel.ReturnUrl))
				{
					return Redirect(loginViewModel.ReturnUrl);
				}

				return RedirectToAction("Index", "Home");
			}

			//Show error
			return View();

		}






		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");


		}




		[HttpGet]
		public IActionResult AccessDenied()
		{


			return View();

		}







	}
}
