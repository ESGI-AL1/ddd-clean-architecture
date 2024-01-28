using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;
using SportPourTous.Domain.ValueObjects;

namespace SportPourTous.Application.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _reservationRepository.GetAllReservationsAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(ReservationId id)
        {
            return await _reservationRepository.GetReservationByIdAsync(id);
        }

        public async Task CreateReservationAsync(Reservation reservation)
        { 
            if (reservation.ReservationId == null)
            {
                reservation.ReservationId = new ReservationId();
            }

            await _reservationRepository.CreateReservationAsync(reservation);
        }



        public async Task UpdateReservationAsync(Reservation reservation)
        {
            await _reservationRepository.UpdateReservationAsync(reservation);
        }

        public async Task DeleteReservationAsync(ReservationId id)
        {
            await _reservationRepository.DeleteReservationAsync(id);
        }
    }
}
