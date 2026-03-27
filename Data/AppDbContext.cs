using Microsoft.EntityFrameworkCore;
using SuruYonetimAPI.Models;

namespace SuruYonetimAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AIAnalysisLog> AIAnalysisLogs { get; set; }
        public DbSet<AIChatHistory> AIChatHistories { get; set; }
    }
}