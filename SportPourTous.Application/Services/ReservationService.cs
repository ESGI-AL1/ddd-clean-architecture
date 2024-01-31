using FluentValidation;
using FluentValidation.Results;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;
using SportPourTous.Infrastructure.Exceptions;

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

        public async Task<Guid> UpdateReservation(Guid id, Reservation updatedReservation)
        {
            ValidationResult result = _validator.Validate(updatedReservation);
            if (!result.IsValid)
            {
                throw new ValidationException("Invalid reservation data", result.Errors);
            }

            var reservation = await _reservationRepository.GetReservation(id);
            if (reservation == null)
            {
                throw new ReservationNotFoundException(id);
            }

            reservation.ReservationDate = updatedReservation.ReservationDate;
            reservation.BeginningHour = updatedReservation.BeginningHour;
            reservation.EndingHour = updatedReservation.EndingHour;

            return await _reservationRepository.UpdateReservation(id, reservation);
        }

    }
}
