using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Net.UI.Data;
using Net.UI.Models.DTO;
using System.Diagnostics;
using System.Security.Claims;

namespace Net.UI.Repository;

public class ImageRepository
{
	private readonly NetDbContext netDbContext;
	private readonly IConfiguration configuration;

	public ImageRepository(NetDbContext netDbContext,IConfiguration configuration)
	{
		this.netDbContext = netDbContext;
		this.configuration = configuration;
	}


	public async Task<bool> UploadUserProfilImageAsync(ClaimsPrincipal user,IFormFile file)
	{
		var userId = user.FindFirstValue(ClaimTypes.NameIdentifier); // Hämtar användar-ID



		try
		{
			if (userId != null && file != null && file.Length != 0)
			{

				var appUser = await netDbContext.AppUsers.FirstOrDefaultAsync(u => u.IdentityUserId == userId);

				if (appUser != null)
				{

					var fileName = $"p_{appUser.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

					var filePath = Path.Combine(Directory.GetCurrentDirectory(), configuration["FileUploadPath"]!, fileName);

					using var fs = new FileStream(filePath, FileMode.Create);

					await file.CopyToAsync(fs);


					var model = new EditDto { ProfilImage = appUser.ProfilImage };







					//model.ProfilImage = fileName;

					//möjligt att den ej funkar för de ej finns updatering async

					appUser.ProfilImage = fileName;

					await netDbContext.SaveChangesAsync();


					return true;
				}


				


			}





		}
		catch (Exception ex)
		{

			Debug.WriteLine(ex.Message);

		}

		return false;


		

	




}








}

