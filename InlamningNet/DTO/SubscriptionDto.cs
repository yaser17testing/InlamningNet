using System.ComponentModel.DataAnnotations;

namespace InlamningNet.DTO
{
    public class SubscriptionDto
    {


        public Guid SubscriptionId { get; set; } // Primary Key






        [EmailAddress]
        [MaxLength(255)]


        public string Email { get; set; }

        public DateTime SubscriptionDate { get; set; }


        public bool? ActiveStatus { get; set; }





    }
}
