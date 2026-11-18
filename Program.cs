using EventHub.Data;
using Microsoft.EntityFrameworkCore;

namespace EventHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<EventHubDbContext>()
                .UseSqlServer(
                    "Server=localhost;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            using var context = new EventHubDbContext(options);

            context.Database.Migrate();

            Console.WriteLine("EventHub Database Created Successfully!");

        }
    }
}
