using Microsoft.EntityFrameworkCore;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;
using SportPourTous.Domain.ValueObjects;
using SportPourTous.Infrastructure.Database;

namespace SportPourTous.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DatabaseContext _context;

        public ReservationRepository(DatabaseContext context) => _context = context;
        
        
        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();
        }
        
        public async Task<Reservation> GetReservationByIdAsync(ReservationId id)
        {
            return await _context.Reservations.FirstOrDefaultAsync(reservation => reservation.ReservationId == id);
        }


        public async Task CreateReservationAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            var existingReservation = await _context.Reservations.FindAsync(reservation.ReservationId);

            if (existingReservation != null)
            {
                existingReservation.Date = reservation.Date;
                existingReservation.BeginningHour = reservation.BeginningHour;
                existingReservation.EndingHour = reservation.EndingHour;
                existingReservation.Location = reservation.Location;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteReservationAsync(ReservationId id)
        {
            var reservationToDelete = await _context.Reservations.FindAsync(id);
            if (reservationToDelete != null)
            {
                _context.Reservations.Remove(reservationToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}