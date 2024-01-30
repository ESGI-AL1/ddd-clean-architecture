using Microsoft.EntityFrameworkCore;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;
using SportPourTous.Infrastructure.Database;
using SportPourTous.Infrastructure.Exceptions;

namespace SportPourTous.Infrastructure.Repositories
{
    public class ReservationRepository : IReservation 
    {
        private readonly DatabaseContext _context;

        public ReservationRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Reservation?> GetReservation(Guid id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                throw new ReservationNotFoundException(id);
            }
            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Guid> CreateReservation(Reservation reservation)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();

            return reservation.Id;
        }

        public async Task<Guid> UpdateReservation(Guid id, Reservation updatedReservation)
        {
            if (updatedReservation == null) throw new ArgumentNullException(nameof(updatedReservation));

            var reservation = await GetReservation(id);

            reservation.BeginningHour = updatedReservation.BeginningHour;
            reservation.EndingHour = updatedReservation.EndingHour;

            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();

            return reservation.Id;
        }

        public async Task DeleteReservation(Guid id)
        {
            var reservation = await GetReservation(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
