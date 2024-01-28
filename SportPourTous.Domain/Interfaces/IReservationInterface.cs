using SportPourTous.Domain.Entities;
using SportPourTous.Domain.ValueObjects;

namespace SportPourTous.Domain.Interfaces;

public interface IReservationRepository
{
    Task<IEnumerable<Reservation>> GetAllReservationsAsync();
    Task<Reservation> GetReservationByIdAsync(ReservationId id);
    Task CreateReservationAsync(Reservation reservation);
    Task UpdateReservationAsync(Reservation reservation);
    Task DeleteReservationAsync(ReservationId id);
}
