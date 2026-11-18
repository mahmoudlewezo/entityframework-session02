namespace EventHub.Entities
{
    public class Badge
    {
        public int BadgeId { get; set; }

        public string BadgeNumber { get; set; } = string.Empty;

        public DateTime IssuedDate { get; set; }

        public BadgeTier Tier { get; set; }

        // Foreign Key
        public int AttendeeId { get; set; }

        // Navigation Property
        public Attendee Attendee { get; set; } = null!;
    }

    public enum BadgeTier
    {
        Standard,
        VIP
    }
}