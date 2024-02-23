using FluentValidation;
using FluentValidation.Results;
using SportPourTous.Application.Interfaces;
using SportPourTous.Domain.CQS.Commands;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;
using SportPourTous.Infrastructure.Exceptions;

namespace SportPourTous.Application.CQS.CommandHandlers
{
    public class UpdateReservationCommandHandler : IUpdateReservationCommandHandler
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IValidator<Reservation> _validator;    

        public UpdateReservationCommandHandler(IReservationRepository repository, IValidator<Reservation> validator)
        {
            _reservationRepository = repository;
            _validator = validator;
        }
        
        public async Task<Guid> HandleUpdateReservation(Guid id, UpdateReservationCommand reservationCommand)
        {
            var reservationToUpdate = await _reservationRepository.GetReservation(id);
            if (reservationToUpdate == null)
            {
                throw new ReservationNotFoundException(id);
            }

            reservationToUpdate.ReservationDate = reservationCommand.ReservationDate;
            reservationToUpdate.BeginningHour = reservationCommand.BeginningHour;
            reservationToUpdate.EndingHour = reservationCommand.EndingHour;

            ValidationResult result = _validator.Validate(reservationToUpdate);
            if (!result.IsValid)
            {
                throw new ValidationException("Invalid reservation data", result.Errors);
            }

            return await _reservationRepository.UpdateReservation(id, reservationToUpdate);
        }
    }
}