using SportPourTous.Domain.CQS.Commands;

namespace SportPourTous.Application.Interfaces
{
    public interface ICreateReservationCommandHandler
    {
        Task<Guid> HandleCreateReservation(CreateReservationCommand reservation);
    }
}
