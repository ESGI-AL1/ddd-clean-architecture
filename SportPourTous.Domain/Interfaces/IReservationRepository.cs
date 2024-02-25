using SportPourTous.Domain.Entities;

namespace SportPourTous.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<Reservation?> GetReservation(Guid id);
        Task<Guid> CreateReservation(Reservation reservation);
        Task<Guid> UpdateReservation(Guid id, Reservation reservation);
        Task DeleteReservation(Guid id);
    }
}
