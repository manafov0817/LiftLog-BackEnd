using LiftLog.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
namespace LiftLog.Data.Concrete.EfCore.Utils
{
    public class EfDbContext : DbContext
    {
        // Add many to many database muscles <-> movements
        public EfDbContext() { }
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;User Id=postgres;Password=maqa1221;Port=5433;Database=LiftLogDb");
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutSessionLog> WorkoutSessionLogs { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movement>()
                          .Property(m => m.MuscleIds)
                          .HasConversion(
                              v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),  // Convert to JSON for the database
                              v => JsonSerializer.Deserialize<List<Guid>>(v, new JsonSerializerOptions())  // Convert back to List from JSON
                          );
        }
    }
}
