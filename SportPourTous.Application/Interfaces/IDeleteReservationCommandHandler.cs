using SportPourTous.Domain.CQS.Commands;

namespace SportPourTous.Application.Interfaces
{
    public interface IDeleteReservationCommandHandler
    {
        Task Handle(DeleteReservationCommand id);
    }
}
