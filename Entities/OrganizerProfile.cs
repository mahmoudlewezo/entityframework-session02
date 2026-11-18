namespace EventHub.Entities
{
    public class OrganizerProfile
    {
        public int Id { get; set; }

        public string? Bio { get; set; }

        public string? Website { get; set; }

        public string? Logo { get; set; }

        // Foreign Key
        public int OrganizerId { get; set; }

        // Navigation Property
        public Organizer Organizer { get; set; } = null!;
    }
}