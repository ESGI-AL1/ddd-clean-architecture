using Microsoft.EntityFrameworkCore;
using SportPourTous.Domain.Entities;

namespace SportPourTous.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Reservation> Reservations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>().OwnsOne(p => p.Prestation, prestation =>
            {
                prestation.WithOwner();

                prestation.Property(p => p.Meal).HasColumnName("MealTray");
                prestation.Property(p => p.Bus).HasColumnName("BusAccess");
            });
        }
    }
}