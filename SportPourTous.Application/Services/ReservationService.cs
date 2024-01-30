using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;

namespace SportPourTous.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Reservation?> GetReservation(Guid id)
        {
            return await _reservationRepository.GetReservation(id);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _reservationRepository.GetAllReservations();
        }

        public async Task<Guid> CreateReservation(Reservation reservation)
        {
            reservation = new Reservation { Id = Guid.NewGuid() }; 
            await _reservationRepository.CreateReservation(reservation);
            return reservation.Id;  
        }

        public async Task<Guid> UpdateReservation(Guid id, Reservation reservation)
        {
            return await _reservationRepository.UpdateReservation(id, reservation);
        }

        public async Task DeleteReservation(Guid id)
        {
            await _reservationRepository.DeleteReservation(id);
        }
    }
}
