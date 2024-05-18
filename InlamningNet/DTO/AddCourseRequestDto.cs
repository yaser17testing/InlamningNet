using System.ComponentModel.DataAnnotations.Schema;

namespace InlamningNet.DTO
{
	public class AddCourseRequestDto
	{


      


        public string Title { get; set; }


        public string Description { get; set; }

        public string ImageUrl { get; set; }




        public decimal Price { get; set; }


        public int Duration { get; set; } // Exempelvis i antal dagar

        public string Author { get; set; }

        public int? Likebutton { get; set; }



    }
}
