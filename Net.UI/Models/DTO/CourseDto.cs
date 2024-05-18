using System.ComponentModel.DataAnnotations.Schema;

namespace Net.UI.Models.DTO
{
    public class CourseDto
    {



        public Guid CourseId { get; set; } // Primary Key


        public string Title { get; set; }


        public string Description { get; set; }

        public string ImageUrl { get; set; }




     
        public decimal Price { get; set; }


        public int Duration { get; set; } // Exempelvis i antal dagar

        public string Author { get; set; }

        public int? Likebutton { get; set; }

    }
}
