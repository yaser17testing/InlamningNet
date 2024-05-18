namespace InlamningNet.DTO
{
    public class SubscriptionPostDto
    {


        public string Email { get; set; }

        public bool IsDailyNewsletterSubscribed { get; set; } = false;
        public bool IsEventUpdatesSubscribed { get; set; } = false;
        public bool IsAdvertisingUpdatesSubscribed { get; set; } = false;
        public bool IsStartUpsWeeklySubscribed { get; set; } = false;
        public bool IsWeekInReviewSubscribed { get; set; } = false;
        public bool IsPodcastsSubscribed { get; set; } = false;

    }
}
