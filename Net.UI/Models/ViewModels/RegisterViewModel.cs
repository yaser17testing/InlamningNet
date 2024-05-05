using System.ComponentModel.DataAnnotations;

namespace Net.UI.Models.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Username is required")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be at least 2 characters long")]
		public string Username { get; set; }


		[Required(ErrorMessage = "Email is required")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[StringLength(50, MinimumLength = 6, ErrorMessage = "password must be at least 6 characters long")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Password must match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password must match.")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "First name is required")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be at least 2 characters long")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Last name is required")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be at least 2 characters long")]
		public string LastName { get; set; }




		public string? AdressOne { get; set; }

		public string? AdressTwo { get; set; }




		public string? PostalCode { get; set; }


		public string? City { get; set; }


	}
}
