using System.ComponentModel.DataAnnotations;

namespace Net.UI.Models.DTO
{
	public class EditDto
	{





		public Guid Id { get; set; }

		public string Email { get; set; }
		public string Name { get; set; }

		public string LastName { get; set; }

		public string? ProfilImage { get; set; }

        public string? Bio { get; set; }


		public string AdressOne { get; set; }

		public string AdressTwo { get; set; }



		
		public string PostalCode { get; set; }

		
		public string City { get; set; }

		

	}
}
