using SportPourTous.Application.Interfaces;
using SportPourTous.Domain.CQRS.Commands;
using SportPourTous.Domain.Interfaces;

namespace SportPourTous.Application.CQRS.CommandHandlers
{
    public class DeleteReservationCommandHandler : IDeleteReservationCommandHandler
    {
        private readonly IReservationRepository _repository;
        public DeleteReservationCommandHandler(IReservationRepository repository) => _repository = repository;
        public async Task Handle(DeleteReservationCommand command)
        {
            await _repository.DeleteReservation(command.Id);
        }
    }
}
