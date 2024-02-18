using SportPourTous.Application.Interfaces;
using SportPourTous.Domain.CQS.Queries;
using SportPourTous.Domain.Entities;
using SportPourTous.Domain.Interfaces;
using SportPourTous.Infrastructure.Exceptions;

public class GetReservationQueryHandler : IGetReservationQueryHandler
{
    private readonly IReservationRepository _repository;

    public GetReservationQueryHandler(IReservationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Reservation> HandleGetReservationById(GetReservationQuery query)
    {
        return await _repository.GetReservation(query.Id)
               ?? throw new ReservationNotFoundException(query.Id);
    }

    public async Task<IEnumerable<Reservation>> HandleGetAllReservations()
    {
        return await _repository.GetAllReservations();
    }
}
