using SportPourTous.Application.Interfaces;
using SportPourTous.Domain.CQS.Commands;
using SportPourTous.Domain.Interfaces;

namespace SportPourTous.Application.CQS.CommandHandlers
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
