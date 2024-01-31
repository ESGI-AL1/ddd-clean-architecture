using FluentValidation;
using FluentValidation.Results;
using SportPourTous.Application.Interfaces;
using SportPourTous.Domain.CQRS.Commands;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;

namespace SportPourTous.Application.CQRS.CommandHandlers
{
    public class CreateReservationCommandHandler : ICreateReservationCommandHandler
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IValidator<Reservation> _validator;    

        public CreateReservationCommandHandler(IReservationRepository repository, IValidator<Reservation> validator)
        {
            _reservationRepository = repository;
            _validator = validator;
        }
        public async Task<Guid> HandleCreateReservation(CreateReservationCommand reservation)
        {
            var reservationToCreate = new Reservation
            {
                Id = Guid.NewGuid(),
                ReservationDate = reservation.ReservationDate,
                BeginningHour = reservation.BeginningHour,
                EndingHour = reservation.EndingHour
            };

            ValidationResult result = _validator.Validate(reservationToCreate);
            if (!result.IsValid)
            {
                throw new ValidationException("Invalid reservation data", result.Errors);
            }

            return await _reservationRepository.CreateReservation(reservationToCreate);
        }
    }
}
