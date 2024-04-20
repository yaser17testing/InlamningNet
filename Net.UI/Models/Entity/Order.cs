using System.ComponentModel.DataAnnotations.Schema;

namespace Net.UI.Models.Entity
{
    public class Order
    {
        public Guid Id { get; set; } // Primary Key


        public Guid UserId { get; set; } // Foreign Key till Users-tabellen

        [ForeignKey("UserId")]
        public AppUser AppUsers { get; set; }


        public string CourseId { get; set; } // Foreign Key till Courses-tabellen




        public DateTime PurchaseDate { get; set; }






    }
}
