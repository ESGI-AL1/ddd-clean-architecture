using Microsoft.EntityFrameworkCore;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;
using SportPourTous.Infrastructure.Database;
using SportPourTous.Infrastructure.Exceptions;

namespace SportPourTous.Infrastructure.Repositories
{
    public class ReservationRepository(DatabaseContext context) : IReservationRepository
    {
        public async Task<Reservation?> GetReservation(Guid id)
        {
            var reservation = await context.Reservations.FindAsync(id);
            
            if (reservation == null)
            {
                throw new ReservationNotFoundException(id);
            }
            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await context.Reservations.ToListAsync();
        }

        public async Task<Guid> CreateReservation(Reservation reservation)
        {
            ArgumentNullException.ThrowIfNull(reservation, nameof(reservation));

            await context.Reservations.AddAsync(reservation);
            await context.SaveChangesAsync();

            return reservation.Id;
        }

        public async Task<Guid> UpdateReservation(Guid id, Reservation reservation)
        {
            context.Reservations.Update(reservation);
            await context.SaveChangesAsync();

            return reservation.Id;
        }

        public async Task DeleteReservation(Guid id)
        {
            var reservation = await GetReservation(id);
            
            if (reservation == null)
            {
                throw new ReservationNotFoundException(id);
            }
            context.Reservations.Remove(reservation);
            await context.SaveChangesAsync();
        }
    }
}