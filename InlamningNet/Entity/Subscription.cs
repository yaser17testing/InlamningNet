using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InlamningNet.Entity
{
    public class Subscription
    {


        public Guid SubscriptionId { get; set; } // Primary Key


      



        [EmailAddress]
        [MaxLength(255)]


        public string Email { get; set; }

        public DateTime SubscriptionDate { get; set; }


        public bool? ActiveStatus { get; set; }


    }
}
