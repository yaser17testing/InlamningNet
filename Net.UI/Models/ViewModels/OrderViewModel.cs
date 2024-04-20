using System.ComponentModel.DataAnnotations.Schema;

namespace Net.UI.Models.ViewModels
{
    public class OrderViewModel
    {

        //public string UserId { get; set; }
        public string CourseId { get; set; } // Foreign Key till Courses-tabellen

        public string Title { get; set; }


        public string Description { get; set; }


       
        public decimal Price { get; set; }


        public int Duration { get; set; }


        public DateTime PurchaseDate { get; set; }



    }
}
