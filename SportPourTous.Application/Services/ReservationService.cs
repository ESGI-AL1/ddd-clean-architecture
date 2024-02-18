using FluentValidation;
using FluentValidation.Results;
using SportPourTous.Application.Interfaces;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;
using SportPourTous.Infrastructure.Exceptions;

namespace SportPourTous.Application.Services
{
    public class ReservationService(IReservationRepository reservationRepository, 
                                    IValidator<Reservation> validator) : IReservationService
    {
        public async Task<Guid> CreateReservation(Reservation reservation)
        {
            reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                ReservationDate = reservation.ReservationDate,
                BeginningHour = reservation.BeginningHour,
                EndingHour = reservation.EndingHour
            };

            ValidationResult result = validator.Validate(reservation);
            if (!result.IsValid)
            {
                throw new ValidationException("Invalid reservation data", result.Errors);
            }

            return await reservationRepository.CreateReservation(reservation);
        }

        public async Task<Guid> UpdateReservation(Guid id, Reservation updatedReservation)
        {
            var result = validator.Validate(updatedReservation);
            if (!result.IsValid)
            {
                throw new ValidationException("Invalid reservation data", result.Errors);
            }

            var reservation = await reservationRepository.GetReservation(id);
            if (reservation == null)
            {
                throw new ReservationNotFoundException(id);
            }

            reservation.ReservationDate = updatedReservation.ReservationDate;
            reservation.BeginningHour = updatedReservation.BeginningHour;
            reservation.EndingHour = updatedReservation.EndingHour;

            return await reservationRepository.UpdateReservation(id, reservation);
        }
    }
}