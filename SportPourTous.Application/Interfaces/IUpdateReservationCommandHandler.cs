using SportPourTous.Domain.CQS.Commands;

namespace SportPourTous.Application.Interfaces
{
    public interface IUpdateReservationCommandHandler
    {
        Task<Guid> HandleUpdateReservation(Guid id, UpdateReservationCommand reservation);
    }
}