using SportPourTous.Application.Interfaces;
using SportPourTous.Domain.Interfaces;

namespace SportPourTous.Application.CQRS.CommandHandlers
{
    public class DeleteReservationCommandHandler : IDeleteReservationCommandHandler
    {
        private readonly IReservationRepository _repository;
        public DeleteReservationCommandHandler(IReservationRepository repository) => _repository = repository;
        public async Task Handle(Guid id)
        {
            await _repository.DeleteReservation(id);
        }
    }
}
