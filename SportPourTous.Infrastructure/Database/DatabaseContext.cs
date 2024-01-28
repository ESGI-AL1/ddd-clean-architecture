using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.ValueObjects;

namespace SportPourTous.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasKey(key => key.ReservationId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Location)
                .WithMany()
                .HasForeignKey(r => r.LocationId); 

            var reservationIdConverter = new ValueConverter<ReservationId, Guid>(
                v => v.ToGuid(),
                v => new ReservationId(v)
            );

            modelBuilder.Entity<Reservation>()
                .Property(r => r.ReservationId)
                .HasConversion(reservationIdConverter);
            
            modelBuilder.Entity<Equipement>().HasNoKey();

        }
    }
}