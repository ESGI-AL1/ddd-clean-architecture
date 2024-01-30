using FluentValidation;
using FluentValidation.Results;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;

namespace SportPourTous.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IValidator<Reservation> _validator;
        public ReservationService(IReservationRepository reservationRepository, IValidator<Reservation> validator)
        {
            _reservationRepository = reservationRepository;
            _validator = validator;
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
            reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                ReservationDate = reservation.ReservationDate,
                BeginningHour = reservation.BeginningHour,  
                EndingHour = reservation.EndingHour
            };

            ValidationResult result = _validator.Validate(reservation);
            if (!result.IsValid)
            {
                throw new ValidationException("Invalid reservation data", result.Errors);
            }

            return await _reservationRepository.CreateReservation(reservation);
        }

        public async Task<Guid> UpdateReservation(Guid id, Reservation reservation)
        {
            return await _reservationRepository.UpdateReservation(id, reservation);
        }
    }
}
