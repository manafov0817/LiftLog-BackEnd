using LiftLog.Entity.Models;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<MuscleMovement> MusclesMovements { get; set; }
        public DbSet<WorkoutSessionLog> WorkoutSessionLogs { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MuscleMovement>().HasKey(c => new { c.MovementId, c.MuscleId });
        }
    }
}
