using LiftLog.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftLog.Data.Concrete.EfCore
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() { }
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;User Id=postgres;Password=maqa1221;Port=5433;Database=LiftLogDb");
        }
        public DbSet<Profile> Profiles { get; set; }
    }
}
