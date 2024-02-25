using FluentValidation;
using FluentValidation.Results;
using SportPourTous.Application.Interfaces;
using SportPourTous.Domain.CQS.Commands;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;
using SportPourTous.Domain.ValueObjects;

namespace SportPourTous.Application.CQS.CommandHandlers
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
        public async Task<Guid> HandleCreateReservation(CreateReservationCommand command)
        {
            var prestation = command.MealTray == true || command.BusAccess == true
                ? new Prestation(command.MealTray ?? false, command.BusAccess ?? false)
                : null;

            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                ReservationDate = command.ReservationDate,
                BeginningHour = command.BeginningHour,
                EndingHour = command.EndingHour,
                Prestation = prestation
            };

            ValidationResult result = _validator.Validate(reservation);
            if (!result.IsValid)
            {
                throw new ValidationException("Invalid reservation data", result.Errors);
            }

            return await _reservationRepository.CreateReservation(reservation);
        }
    }
}
