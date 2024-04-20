using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net.UI.Models.Entity
{
    public class Adress
    {

        public Guid Id { get; set; }


        public Guid AppUserId { get; set; } // Foreign Key till Users-tabellen

        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }

   
        public string AdressOne { get; set; }

        public string? AdressTwo { get; set; }



       
        public string PostalCode { get; set; }

       
        public string City { get; set; }

    }
}
