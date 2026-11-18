using EventHub.Entities;
using EventHub.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Data
{
    public class EventHubDbContext : DbContext
    {
        public EventHubDbContext(DbContextOptions<EventHubDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Badge> Badges { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =================================
            // OrganizerProfile Configuration
            // Fluent API - Direct Configuration
            // =================================

            modelBuilder.Entity<OrganizerProfile>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Bio)
                      .HasMaxLength(1000);

                entity.Property(p => p.Website)
                      .HasMaxLength(300);

                entity.Property(p => p.Logo)
                      .HasMaxLength(500);

                // One-to-One Relationship
                entity.HasOne(p => p.Organizer)
                      .WithOne(o => o.Profile)
                      .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                      .IsRequired();
            });


            // =================================
            // Apply Separate Configurations
            // =================================

            modelBuilder.ApplyConfiguration(new EventConfiguration());

            modelBuilder.ApplyConfiguration(new BadgeConfiguration());
        }
    }
}
