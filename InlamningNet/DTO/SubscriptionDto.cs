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



        public bool IsDailyNewsletterSubscribed { get; set; } = false;
        public bool IsEventUpdatesSubscribed { get; set; } = false;
        public bool IsAdvertisingUpdatesSubscribed { get; set; } = false;
        public bool IsStartUpsWeeklySubscribed { get; set; } = false;
        public bool IsWeekInReviewSubscribed { get; set; } = false;
        public bool IsPodcastsSubscribed { get; set; } = false;





    }
}
