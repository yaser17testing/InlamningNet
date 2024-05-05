using System.ComponentModel.DataAnnotations;

namespace Net.UI.Models.ViewModels
{
	public class LoginViewModel
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
